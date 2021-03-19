using System;

namespace General.Stats
{
    [Serializable]
    public sealed class Health
    {
        public int Max { get; }
        public int Current { get; private set; }
        
        public Health(int max, int current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentHealth(int hp)
        {
            Current = hp;
        }
    }

}