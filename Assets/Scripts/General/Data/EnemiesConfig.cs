using System;
using System.Collections.Generic;
using System.Linq;
using General.Enemies;
using UnityEngine;

namespace General
{
    [Serializable] 
    public class EnemyInfo
    {
        public EnemyType Type;
        public Enemy EnemyPrefab;
        public int HP;
        public float Speed;
        public Transform SpawnPosition;
    }
    
    [CreateAssetMenu(fileName = "EnemiesConfig", menuName = "Configs/EnemiesConfig", order = 0)]
    public class EnemiesConfig : ScriptableObject
    {
        [SerializeField] 
        private List<EnemyInfo> _enemies;

        public List<EnemyInfo> Enemies => _enemies;
        
        public (Enemy enemy, int hp) GetEnemy(EnemyType type)
        {
            var enemyInfo = _enemies.First(info => info.Type == type);
            return (enemyInfo.EnemyPrefab, enemyInfo.HP);
        }
    }
}