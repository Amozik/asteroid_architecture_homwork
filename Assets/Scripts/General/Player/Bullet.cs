using System;
using General.Extension;
using UnityEngine;

namespace General.Player
{
    public class Bullet : MonoBehaviour
    {
        public event Action<GameObject> OnBecameInvisibleEvent;

        internal static GameObject CreateBullet(Sprite sprite)
        {
            var bullet = new GameObject("Bullet")
                .AddSprite(sprite)
                .AddRigidbody2D(1)
                .AddBoxCollider2D(new Vector2(0.12f, 0.12f), true);
            bullet.AddComponent<Bullet>();

            return bullet;
        }
        
        private void OnBecameInvisible()
        {
            OnBecameInvisibleEvent?.Invoke(gameObject);
        }
    }
}