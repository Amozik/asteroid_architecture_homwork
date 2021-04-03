using System;
using System.Collections.Generic;
using General.Controllers;
using General.Interfaces;
using General.MessageBroker;
using General.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace General.Enemies
{
    public class EnemySpawner : ISpawner, IInitialization, ICleanup
    {
        private Vector3 _position;
        private Enemy _enemy;

        public event Action<IEnemy> OnSpawnEnemy;

        public EnemySpawner(Enemy enemy)
        {
            _position = enemy.transform.position;
            _enemy = enemy;
        }
        
        public void Initialization()
        {
            _enemy.OnTriggerEnterChange += OnTriggerEnemy;
        }

        public void Cleanup()
        {
            _enemy.OnTriggerEnterChange += OnTriggerEnemy;
        }

        private Enemy SpawnEnemy()
        {
            var newEnemy = _enemy.Clone();
            newEnemy.Health.ChangeCurrentHealth(newEnemy.Health.Max);
            newEnemy.transform.position = _position;
            newEnemy.OnTriggerEnterChange += OnTriggerEnemy;
            
            OnSpawnEnemy?.Invoke(newEnemy);

            return newEnemy;
        }

        private void OnTriggerEnemy(GameObject other)
        {
            if (other.GetComponent<Bullet>() || other.GetComponent<PlayerBase>())
            {
                _enemy.Health.ChangeCurrentHealth(_enemy.Health.Current - 1);
                if (_enemy.Health.Current <= 0)
                {
                    _enemy.OnTriggerEnterChange -= OnTriggerEnemy;
                    var newEnemy = SpawnEnemy();
                    Object.Destroy(_enemy.gameObject);
                    _enemy.OnDestroy?.Invoke(_enemy.ToString());
                    _enemy = newEnemy;
                    
                    var message = new EnemyDestroyMessage()
                    {
                        points = _enemy.Points
                    };
                    SimpleMessageBroker.Publish<EnemyDestroyMessage>(message);
                }
            }
        }
    }

    public class EnemyDestroyMessage
    {
        public int points;
    }
}