using System;
using UnityEngine;

namespace General.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        private int _hp;

        public int HP => _hp;
        
        public event Action<int> OnTriggerEnterChange;
        
        internal static Ship CreateShipEnemy(Ship enemyPrefab, int hp)
        {
            var enemy = Instantiate(enemyPrefab);
        
            enemy._hp = hp;
        
            return enemy;
        }
        
        internal static Asteroid CreateAsteroidEnemy(Asteroid enemyPrefab, int hp)
        {
            var enemy = Instantiate(enemyPrefab);
        
            enemy._hp = hp;
        
            return enemy;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID());
        }
    }
}