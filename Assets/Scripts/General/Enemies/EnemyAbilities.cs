using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace General.Enemies
{
    public class EnemyAbilities : IEnumerable
    {
        private List<IAbility> _abilities;
        
        public int MaxDamage => _abilities.Select(a => a.Damage).Max();
        
        public EnemyAbilities(List<IAbility> abilities)
        {
            _abilities = abilities;
        }
        
        public IAbility this[int index] => _abilities[index];

        public IEnumerator GetEnumerator()
        {
            return _abilities.GetEnumerator();
        }
    }
}