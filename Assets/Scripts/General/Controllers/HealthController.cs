using General.Interfaces;
using General.Player;
using UnityEngine;

namespace General.Controllers
{
    internal class HealthController : IInitialization, ICleanup
    {
        private float _hp;
        private PlayerBase _player;

        public HealthController(PlayerBase player)
        {
            _player = player;
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