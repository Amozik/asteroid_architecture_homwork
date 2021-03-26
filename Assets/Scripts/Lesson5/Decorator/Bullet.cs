using UnityEngine;

namespace Lesson5.Decorator
{
    internal sealed class Bullet : IAmmunition
    {
        public Rigidbody2D BulletInstance { get; }
        public float TimeToDestroy { get; }
        
        public Bullet(Rigidbody2D bulletInstance, float timeToDestroy)
        {
            BulletInstance = bulletInstance;
            TimeToDestroy = timeToDestroy;
        }
    }
}