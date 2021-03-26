using System;

namespace Lesson5.Composite
{
    [Serializable]
    public class EnemyData
    {
        public UnitData unit;
    }
    
    [Serializable]
    public class UnitData
    {
        public string type;
        public int health;
    }
}