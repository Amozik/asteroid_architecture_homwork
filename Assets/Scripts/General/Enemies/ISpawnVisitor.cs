namespace General.Enemies
{
    public interface ISpawnVisitor
    {
        void Visit(Enemy unit, string type);

    }
}