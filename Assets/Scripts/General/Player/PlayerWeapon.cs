using General.Pool;
using UnityEngine;

namespace General.Player
{
    internal class PlayerWeapon : IWeapon
    {
        private Transform _bulletSpawner;
        private Rigidbody2D _bullet;
        private float _force;
        private ViewServices _bulletPool;

        public PlayerWeapon(Transform bulletSpawner, Rigidbody2D bullet, float force)
        {
            _bulletSpawner = bulletSpawner;
            _bullet = bullet;
            _force = force;
            _bulletPool = new ViewServices();
        }
        
        public void Shoot()
        {
            var temAmmunition = _bulletPool.Create(_bullet.gameObject);
            temAmmunition.transform.position = _bulletSpawner.position;
            
            //var temAmmunition = Object.Instantiate(_bullet, _bulletSpawner.position, _bulletSpawner.rotation);
            temAmmunition.GetComponent<Rigidbody2D>().AddForce(_bulletSpawner.up * _force);
            //temAmmunition.GetComponent<Bullet>().OnBecameInvisibleEvent += OnBulletOutOfCamera;
            temAmmunition.GetComponent<Bullet>().OnBecameInvisibleEvent += gameObject => _bulletPool.Destroy(_bullet.gameObject, gameObject);
        }
    }
}