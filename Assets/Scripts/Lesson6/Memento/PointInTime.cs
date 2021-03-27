using UnityEngine;

namespace Lesson6.Memento
{
    public sealed class PointInTime
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector2 Velocity;
        public float AngularVelocity;

        public PointInTime (Vector3 position, Quaternion rotation, Vector2 velocity, float angularVelocity)
        {
            Position = position;
            Rotation = rotation;
            Velocity = velocity;
            AngularVelocity = angularVelocity;
        }
    }
}