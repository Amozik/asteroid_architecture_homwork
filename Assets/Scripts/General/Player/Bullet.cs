using System;
using UnityEngine;

namespace General.Player
{
    public class Bullet : MonoBehaviour
    {
        public event Action<GameObject> OnBecameInvisibleEvent;
        
        private void OnBecameInvisible()
        {
            OnBecameInvisibleEvent?.Invoke(gameObject);
        }
    }
}