using System;

namespace General.Player
{
    public class WeaponProxy : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly LockedWeapon _lockedWeapon;
        public event Action OnShoot;

        public WeaponProxy(IWeapon weapon, LockedWeapon lockedWeapon)
        {
            _weapon = weapon;
            _lockedWeapon = lockedWeapon;
            _weapon.OnShoot += OnShoot;
        }

        public void Shoot()
        {
            if (!_lockedWeapon.IsLocked)
            {
                _weapon.Shoot();
            }
        }
    }
}