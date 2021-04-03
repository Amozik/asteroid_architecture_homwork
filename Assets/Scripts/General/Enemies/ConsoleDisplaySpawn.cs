using UnityEngine;

namespace General.Enemies
{
    public class ConsoleDisplaySpawn : ISpawnVisitor
    {
        public void Visit(Enemy unit, string type)
        {
            Debug.Log($"Spawn new {nameof(Enemy)} - {type}");
        }
    }
}