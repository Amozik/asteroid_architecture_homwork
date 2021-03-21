namespace General.Enemies
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy(EnemyType type);
    }
}