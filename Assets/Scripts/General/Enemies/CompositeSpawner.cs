using System;
using System.Collections.Generic;
using General.Interfaces;
using General.Player;

namespace General.Enemies
{
    public class CompositeSpawner : ISpawner
    {
        public event Action<IEnemy> OnSpawnEnemy;
        
        private List<ISpawner> _spawners = new List<ISpawner>();
        
        public void AddUnit(ISpawner unit)
        {
            unit.OnSpawnEnemy += OnSpawnEnemy;
            
            _spawners.Add(unit);
        }

        public void RemoveUnit(ISpawner unit)
        {
            unit.OnSpawnEnemy += OnSpawnEnemy;
            _spawners.Remove(unit);
        }
    }
}