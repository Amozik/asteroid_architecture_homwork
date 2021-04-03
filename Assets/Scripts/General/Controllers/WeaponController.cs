using General.Interfaces;
using General.Player;
using General.Player.States;
using UnityEngine;

namespace General.Controllers
{
    public class WeaponController : ICleanup, IExecute
    {
        private IWeapon _weapon;
        private IUserButtonProxy _fireInputProxy;
        private LockedWeapon _lockedWeapon;
        private PlayerBase _player;
        private float _cooldown;
        private float _accumulatedTime = 0;

        public WeaponController(IUserButtonProxy fireInput, PlayerBase player, IWeapon weapon, float cooldown)
        {
            _player = player;
            _lockedWeapon = new LockedWeapon(false);
            _weapon = new WeaponProxy(weapon, _lockedWeapon);
            _weapon.OnShoot += OnShoot;
            _cooldown = cooldown;
            _fireInputProxy = fireInput;
            _fireInputProxy.ButtonOnDown += OnFire;
            _player.OnCollisionEnterChange += OnCollisionPlayer;
        }

        private void OnFire(bool value)
        {
            if (value)
                _weapon.Shoot();
        }

        private void OnCollisionPlayer(GameObject other)
        {
            if (other.GetComponent<Bullet>())
                return;
            
            _lockedWeapon.IsLocked = true;
            _player.State = new FreezeState();
            _player.RequestState();
        }

        private void OnShoot()
        {
            _player.State = new FireState();
            _player.RequestState();
        }

        public void Cleanup()
        {
            _fireInputProxy.ButtonOnDown -= OnFire;
            _player.OnCollisionEnterChange -= OnCollisionPlayer;
            _weapon.OnShoot -= OnShoot;
        }

        public void Execute(float deltaTime)
        {
            if (!_lockedWeapon.IsLocked)
                return;
            
            _accumulatedTime += deltaTime;
            if (_accumulatedTime > _cooldown)
            {
                _lockedWeapon.IsLocked = false;
                _accumulatedTime = 0;
            }
        }
    }
}