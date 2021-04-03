namespace General.Enemies
{
    public class Ability : IAbility
    {
        public string Name { get; }
        public int Damage { get; }
        
        public Ability(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}