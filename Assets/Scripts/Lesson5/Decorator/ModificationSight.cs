using UnityEngine;

namespace Lesson5.Decorator
{
    internal class ModificationSight : ModificationWeapon
    {
        private ITelescopicSight _sight;
        private Vector3 _sightPosition;
        private GameObject _sightObject;

        public ModificationSight(ITelescopicSight sight, Vector3 sightPosition)
        {
            _sight = sight;
            _sightPosition = sightPosition;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            _sightObject = Object.Instantiate(_sight.SightInstance, _sightPosition, Quaternion.identity);

            weapon.SetForce(_sight.SightForce);
            return weapon;
        }

        protected override void RemoveModification()
        {
            Object.Destroy(_sightObject);
        }
    }
}