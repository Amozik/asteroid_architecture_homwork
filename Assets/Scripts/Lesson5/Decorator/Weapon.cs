using System.Collections.Generic;
using UnityEngine;

namespace Lesson5.Decorator
{
    internal class Weapon : IFire
    {
        private Transform _barrelPosition;
        private IAmmunition _bullet;
        private float _force;
        private AudioClip _audioClip;
        private readonly AudioSource _audioSource;

        public List<ModificationWeapon> Modifications { get; set; }

        public Weapon(IAmmunition bullet, Transform barrelPosition, float force, AudioSource audioSource, AudioClip audioClip)
        {
            _bullet = bullet;
            _barrelPosition = barrelPosition;
            _force = force;
            _audioSource = audioSource;
            _audioClip = audioClip;
        }

        protected Weapon()
        {
        }

        public virtual void SetBarrelPosition(Transform barrelPosition)
        {
            _barrelPosition = barrelPosition;
        }

        public virtual void SetBullet(IAmmunition bullet)
        {
            _bullet = bullet;
        }

        public virtual void SetForce(float force)
        {
            _force = force;
        }

        public virtual void SetAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }

        public virtual void Fire()
        {
            var bullet = Object.Instantiate(_bullet.BulletInstance, _barrelPosition.position, Quaternion.identity);
            bullet.AddForce(_barrelPosition.forward * _force);
            Object.Destroy(bullet.gameObject, _bullet.TimeToDestroy);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}