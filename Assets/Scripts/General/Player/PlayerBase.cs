using System;
using UnityEngine;

namespace General.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField]
        private Transform _barrel;
        public Transform Barrel => _barrel;
        public Animator Animator;
        public State State;

        public event Action<GameObject> OnCollisionEnterChange;
        
        public void RequestState()
        {
            State.Handle(this);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnCollisionEnterChange?.Invoke(other.gameObject);
        }
    }
}