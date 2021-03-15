using System;
using UnityEngine;

namespace General.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField]
        private Transform _barrel;
        public Transform Barrel => _barrel;

        public event Action<GameObject> OnCollisionEnterChange;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollisionEnterChange?.Invoke(other.gameObject);
        }
    }
}