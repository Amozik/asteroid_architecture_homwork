using System;

namespace General.Enemies
{
    public interface IEnemy
    {
        event Action<int> OnTriggerEnterChange;
    }
}