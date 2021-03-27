using System;
using General.Stats;
using UnityEngine;

namespace General.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public Health Health { get; private set; }
        public int Points { get; private set; }
        public event Action<GameObject> OnTriggerEnterChange;
        public event Action<Enemy> OnClone;

        private Enemy _enemyPrefab;
        
        internal static Ship CreateShipEnemy(Ship enemyPrefab, int hp, int points)
        {
            var enemy = Instantiate(enemyPrefab);
        
            enemy.Health = new Health(hp, hp);
            enemy.Points = points;
            enemy._enemyPrefab = enemyPrefab;
        
            return enemy;
        }
        
        internal static Asteroid CreateAsteroidEnemy(Asteroid enemyPrefab, int hp, int points)
        {
            var enemy = Instantiate(enemyPrefab);
        
            enemy.Health = new Health(hp, hp);
            enemy.Points = points;
            enemy._enemyPrefab = enemyPrefab;
            
            return enemy;
        }

        public Enemy Clone()
        {
            var enemy = Instantiate(_enemyPrefab);

            enemy.Health = new Health(Health.Max, Health.Current);
            enemy.Points = Points;
            enemy._enemyPrefab = _enemyPrefab;
            
            OnClone?.Invoke(enemy);
            
            return enemy;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject);
        }
    }
}