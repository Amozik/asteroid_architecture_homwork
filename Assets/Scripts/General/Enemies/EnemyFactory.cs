using System;

namespace General.Enemies
{
    internal class EnemyFactory : IEnemyFactory
    {
        private readonly EnemiesConfig _enemies;
        
        public EnemyFactory(EnemiesConfig enemiesConfig)
        {
            _enemies = enemiesConfig;
        }
        
        public IEnemy CreateEnemy(EnemyType type)
        {
            var (enemy, hp, points) = _enemies.GetEnemy(type);

            switch (type)
            {
                case EnemyType.Asteroid:
                    return Enemy.CreateAsteroidEnemy((Asteroid) enemy, hp, points);
                    break;
                case EnemyType.Ship:
                    return Enemy.CreateShipEnemy((Ship) enemy, hp, points);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}