﻿using System.Collections.Generic;
using General.Enemies;
using General.Interfaces;
using General.Player;
using General.UI;
using UnityEngine;

namespace General.Controllers
{
    public class EnemyInitialization : IInitialization
    {
        private readonly IEnemyFactory _enemyFactory;
        private CompositeMove _enemy;
        private List<Enemy> _enemies;
        private DisplayDestroyedEnemies _displayDestroyedEnemies;
        
        public EnemyInitialization(EnemiesConfig enemiesConfig, DisplayDestroyedEnemies displayDestroyedEnemies)
        {
            _enemyFactory = new EnemyFactory(enemiesConfig);;
            _enemy = new CompositeMove();
            _enemies = new List<Enemy>();
            _displayDestroyedEnemies = displayDestroyedEnemies;
                
            foreach (var enemyInfo in enemiesConfig.Enemies)
            {
                var enemy = (Enemy) _enemyFactory.CreateEnemy(enemyInfo.Type);
                AddMove(enemy, enemyInfo.Speed);
                _displayDestroyedEnemies.Add(enemy);
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

        public IEnumerable<Enemy> GetEnemies()
        {
            foreach (var enemy in _enemies)
            {
                yield return enemy;
            }
        }

        private void AddMove(Enemy enemy, float speed)
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
            enemy.OnClone += newEnemy =>
            {
                _enemy.RemoveUnit(move);
                AddMove(newEnemy, speed);
                _displayDestroyedEnemies.Add(enemy);
                _enemies.Add(newEnemy);
            };
        }
    }
}