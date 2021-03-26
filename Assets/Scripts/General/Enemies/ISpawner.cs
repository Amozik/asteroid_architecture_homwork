using System;

namespace General.Enemies
{
    public interface ISpawner
    {
        public event Action<IEnemy> OnSpawnEnemy;
    }
}