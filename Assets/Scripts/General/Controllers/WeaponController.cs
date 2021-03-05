using General.Interfaces;
using General.Player;

namespace General.Controllers
{
    public class WeaponController : ICleanup
    {
        private IWeapon _weapon;
        private IUserButtonProxy _fireInputProxy;

        public WeaponController(IUserButtonProxy fireInput, IWeapon weapon)
        {
            _weapon = weapon;
            _fireInputProxy = fireInput;
            _fireInputProxy.ButtonOnDown += OnFire;
        }

        private void OnFire(bool value)
        {
            if (value)
                _weapon.Shoot();
        }

        public void Cleanup()
        {
            _fireInputProxy.ButtonOnDown -= OnFire;
        }
    }
}