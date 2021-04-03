using System;
using System.Collections.Generic;
using General.Enemies;
using General.Interfaces;

namespace General.Controllers
{
    public class SpawnerInitialization : IInitialization, ICleanup
    {
        private CompositeSpawner _spawner = new CompositeSpawner();
        private List<EnemySpawner> _spawners = new List<EnemySpawner>();
        
        public SpawnerInitialization(IEnumerable<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                var spawner = new EnemySpawner(enemy);
                _spawner.AddUnit(spawner);
                _spawners.Add(spawner);
            }
        }
        
        public ISpawner GetSpawner()
        {
            return _spawner;
        }
        
        public IEnumerable<EnemySpawner> GetEnemySpawners()
        {
            foreach (var spawner in _spawners)
            {
                yield return spawner;
            }
        }

        public void Initialization()
        {
            foreach (var spawner in _spawners)
            {
                spawner.Initialization();
            }
        }

        public void Cleanup()
        {
            foreach (var spawner in _spawners)
            {
                spawner.Cleanup();
            }
        }
    }
}