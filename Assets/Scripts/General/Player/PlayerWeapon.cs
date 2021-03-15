using General.Pool;
using UnityEngine;

namespace General.Player
{
    internal class PlayerWeapon : IWeapon
    {
        private Transform _bulletSpawner;
        private GameObject _bullet;
        private float _force;
        private ViewServices _bulletPool;

        public PlayerWeapon(Transform bulletSpawner, Rigidbody2D bullet, Sprite bulletSprite, float force)
        {
            _bulletSpawner = bulletSpawner;
            _force = force;
            _bulletPool = new ViewServices();
            _bullet = Bullet.CreateBullet(bulletSprite);
            _bullet.SetActive(false);
        }
        
        public void Shoot()
        {
            var temAmmunition = _bulletPool.Create(_bullet);
            temAmmunition.transform.position = _bulletSpawner.position;
            
            temAmmunition.GetComponent<Rigidbody2D>().AddForce(_bulletSpawner.up * _force);
            temAmmunition.GetComponent<Bullet>().OnBecameInvisibleEvent += gameObject => _bulletPool.Destroy(_bullet, gameObject);
        }
    }
}