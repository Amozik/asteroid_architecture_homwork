using UnityEngine;

namespace Lesson5.Decorator
{
    public interface IAmmunition
    {
        Rigidbody2D BulletInstance { get; }
        float TimeToDestroy { get; }
    }
}