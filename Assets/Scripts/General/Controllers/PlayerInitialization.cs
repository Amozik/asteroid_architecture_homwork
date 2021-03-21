using General.Interfaces;
using General.Player;
using UnityEngine;

namespace General.Controllers
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private PlayerBase _player;
        private IMove _move;
        private IWeapon _weapon;

        public PlayerBase Player => _player;
        public IMove Move => _move;
        public IWeapon Weapon => _weapon;

        public PlayerInitialization(PlayerConfig playerConfig)
        {
            _player = Object.Instantiate(playerConfig.playerPrefab);

            var rigidbody = _player.GetComponent<Rigidbody2D>();

            if (rigidbody)
            {
               _move = new MoveRigidbody(rigidbody, playerConfig.playerSpeed); 
            }
            else
            {
                _move = new MoveTransform(_player.transform, playerConfig.playerSpeed);
            }
            
            _weapon = new PlayerWeapon(_player.Barrel, playerConfig.bullet, playerConfig.bulletSprite, playerConfig.bulletForce);

        }

        public void Initialization()
        {

        }
    }
}