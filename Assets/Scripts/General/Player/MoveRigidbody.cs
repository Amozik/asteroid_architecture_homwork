using UnityEngine;

namespace General.Player
{
    internal class MoveRigidbody : IMove
    {
        private Rigidbody2D _rigidbody;
        private Vector3 _force;
        
        public MoveRigidbody(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;
        }
        
        public float Speed { get; }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _force.Set(horizontal, vertical, 0.0f);
            _rigidbody.AddForce(_force * speed);
        }
    }
}