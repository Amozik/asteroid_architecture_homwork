namespace General.Enemies
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(EnemyType type);
    }
}