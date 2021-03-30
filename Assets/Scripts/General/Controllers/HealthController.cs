using System;
using General.Enemies;
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

        private void OnCollisionPlayer(GameObject other)
        {
            var enemy = other.GetComponent<Enemy>();
            
            if (!enemy)
                return;
            
            if (_hp <= 0)
            {
                Object.Destroy(_player);
                OnDeath?.Invoke();
            }
            else
            {
                _hp -= enemy.Abilities.MaxDamage;
            }
        }
        
        public void Cleanup()
        {
            _player.OnCollisionEnterChange -= OnCollisionPlayer;
        }
    }
}