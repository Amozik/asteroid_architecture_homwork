using System;
using General.Interfaces;
using General.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace General.Controllers
{
    internal class HealthController : IInitialization, ICleanup
    {
        private float _hp;
        private PlayerBase _player;
        public event Action OnDeath;

        public HealthController(PlayerBase player, float hp)
        {
            _player = player;
            _hp = hp;
        }

        public void Initialization()
        {
            _player.OnCollisionEnterChange += OnCollisionPlayer;
        }

        private void OnCollisionPlayer(GameObject enemy)
        {
            if (_hp <= 0)
            {
                Object.Destroy(_player);
                OnDeath?.Invoke();
            }
            else
            {
                _hp--;
            }
        }
        
        public void Cleanup()
        {
            _player.OnCollisionEnterChange -= OnCollisionPlayer;
        }
    }
}