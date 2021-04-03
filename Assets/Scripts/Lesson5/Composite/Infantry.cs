namespace Lesson5.Composite
{
    public class Infantry : IEnemy
    {
        public int Health { get; set; }

        public static Infantry CreateEnemy(int health)
        {
            return new Infantry()
            {
                Health = health
            };
        }
    }
}