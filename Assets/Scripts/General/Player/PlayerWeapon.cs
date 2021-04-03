using System;
using General.Enemies;
using General.Interfaces;
using General.Managers;
using General.Pool;
using UnityEngine;

namespace General.Player
{
    internal class PlayerWeapon : IWeapon
    {
        private Transform _bulletSpawner;
        private GameObject _bullet;
        private float _force;
        private IViewService _pool;
        public event Action OnShoot;

        public PlayerWeapon(Transform bulletSpawner, Rigidbody2D bullet, Sprite bulletSprite, float force)
        {
            _bulletSpawner = bulletSpawner;
            _force = force;
            _pool = ServiceLocator.Resolve<IViewService>();
            _bullet = Bullet.CreateBullet(bulletSprite);
            _bullet.SetActive(false);
        }
        
        public void Shoot()
        {
            var temAmmunition = _pool.Create(_bullet);
            temAmmunition.transform.position = _bulletSpawner.position;
            
            temAmmunition.GetComponent<Rigidbody2D>().AddForce(_bulletSpawner.up * _force);
            temAmmunition.GetComponent<Bullet>().OnBecameInvisibleEvent += gameObject => _pool.Destroy(_bullet, gameObject);
            
            OnShoot?.Invoke();
        }
    }
}