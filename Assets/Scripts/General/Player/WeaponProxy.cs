namespace General.Player
{
    public class WeaponProxy : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly LockedWeapon _lockedWeapon;

        public WeaponProxy(IWeapon weapon, LockedWeapon lockedWeapon)
        {
            _weapon = weapon;
            _lockedWeapon = lockedWeapon;
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