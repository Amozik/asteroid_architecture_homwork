namespace Lesson5.Composite
{
    public class Mag : IEnemy
    {
        public int Health { get; set; }

        public static Mag CreateEnemy(int health)
        {
            return new Mag()
            {
                Health = health 
            };
        }
    }
}