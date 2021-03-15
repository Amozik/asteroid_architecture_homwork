using UnityEngine;

namespace General.Player
{
    internal class PlayerWeapon : IWeapon
    {
        private Transform _bulletSpawner;
        private Rigidbody2D _bullet;
        private float _force;

        public PlayerWeapon(Transform bulletSpawner, Rigidbody2D bullet, float force)
        {
            _bulletSpawner = bulletSpawner;
            _bullet = bullet;
            _force = force;
        }
        
        public void Shoot()
        {
            var temAmmunition = Object.Instantiate(_bullet, _bulletSpawner.position, _bulletSpawner.rotation);
            temAmmunition.AddForce(_bulletSpawner.up * _force);
        }
    }
}