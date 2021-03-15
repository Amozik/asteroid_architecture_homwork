using System.Collections.Generic;
using General.Enemies;
using General.Interfaces;
using General.Player;
using UnityEngine;

namespace General.Controllers
{
    public class EnemyInitialization : IInitialization
    {
        private readonly IEnemyFactory _enemyFactory;
        private CompositeMove _enemy;
        private List<IEnemy> _enemies;

        public EnemyInitialization(EnemiesConfig enemiesConfig)
        {
            _enemyFactory = new EnemyFactory(enemiesConfig);;
            _enemy = new CompositeMove();
            _enemies = new List<IEnemy>();
                
            foreach (var enemyInfo in enemiesConfig.Enemies)
            {
                var enemy = _enemyFactory.CreateEnemy(enemyInfo.Type);
                AddMove(enemy, enemyInfo.Speed);
                _enemies.Add(enemy);
            }
        }
        
        public void Initialization()
        {
        }
        
        public IMove GetMoveEnemies()
        {
            return _enemy;
        }

        public IEnumerable<IEnemy> GetEnemies()
        {
            foreach (var enemy in _enemies)
            {
                yield return enemy;
            }
        }

        private void AddMove(Component enemy, float speed)
        {
            var rigidbody = enemy.GetComponent<Rigidbody2D>();

            IMove move;
            
            if (rigidbody)
            {
                move = new MoveRigidbody(rigidbody, speed); 
            }
            else
            {
                move = new MoveTransform(enemy.transform, speed);
            }
            
            _enemy.AddUnit(move);
        }
    }
}