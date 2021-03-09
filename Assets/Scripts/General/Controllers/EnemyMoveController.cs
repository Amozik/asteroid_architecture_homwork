using General.Interfaces;
using General.Player;
using UnityEngine;

namespace General.Controllers
{
    public class EnemyMoveController : IExecute
    {
        private readonly IMove _move;
        private Vector2 _direction = new Vector2(0, -1);

        public EnemyMoveController(IMove move)
        {
            _move = move;
        }
        
        public void Execute(float deltaTime)
        {
            _move.Move(_direction.x, _direction.y, deltaTime);
        }
    }
}