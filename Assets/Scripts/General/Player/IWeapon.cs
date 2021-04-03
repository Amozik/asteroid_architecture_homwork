using System;

namespace General.Player
{
    public interface IWeapon
    {
        void Shoot();
        event Action OnShoot;
    }
}