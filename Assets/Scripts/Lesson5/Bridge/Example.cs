using UnityEngine;

namespace Lesson5.Bridge
{
    internal sealed class Example : MonoBehaviour
    {
        private void Start()
        {
            var magicalInfantry = new Enemy(new MagicalAttack(), new Infantry());
            var meleeInfantry = new Enemy(new MeleeAttack(), new Infantry());
            var rangedNavy = new Enemy(new RangedAttack(), new Navy());
        }
    }
}
