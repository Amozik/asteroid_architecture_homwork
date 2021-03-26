using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Lesson5.Composite
{
    public class CompositeFactory
    {
        public List<IEnemy> CreateEnemies()
        {
            var textData = File.ReadAllText("Assets/Scripts/Lesson5/Composite/data.json");
            var enemiesData = JsonUtility.FromJson<EnemiesData>(textData);

            var enemies = new List<IEnemy>();
            foreach (var enemyData in enemiesData.enemies)
            {
                var unit = enemyData.unit;
                switch (unit.type)
                {
                    case "mag":
                        var mag = Mag.CreateEnemy(unit.health);
                        enemies.Add(mag);
                        break;
                    case "infantry":
                        var infantry = Infantry.CreateEnemy(unit.health);
                        enemies.Add(infantry);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(unit.type), unit.type, null);
                }
            }

            return enemies;
        }

        private class EnemiesData
        {
            public List<EnemyData> enemies;
        }
    }
}