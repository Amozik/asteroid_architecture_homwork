using General.Extension;
using UnityEngine;

namespace Lesson5.Decorator
{
    internal abstract class ModificationWeapon : Weapon
    {
        private Weapon _weapon;
        private Weapon _backupWeapon;
        
        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract void RemoveModification();
        
        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
            _backupWeapon = weapon.DeepCopy();
        }

        public void UnApplyModification(Weapon weapon)
        {
            _weapon = _backupWeapon;

            var applyModification = false;
            for (var i = 0; i < weapon.Modifications.Count; i++)
            {
                var modification = weapon.Modifications[i];

                if (applyModification)
                {
                    modification.RemoveModification();
                    modification.ApplyModification(_weapon);
                } 
                else if (modification.Equals(this))
                {
                    RemoveModification();
                    applyModification = true;
                    weapon.Modifications.RemoveAt(i);
                }
            }
        }
        
        public override void Fire()
        {
            _weapon.Fire();
        }

        public override void SetBarrelPosition(Transform barrelPosition)
        {
            _weapon.SetBarrelPosition(barrelPosition);
        }
        
        public override void SetBullet(IAmmunition bullet)
        {
            _weapon.SetBullet(bullet);
        }

        public override void SetForce(float force)
        {
            _weapon.SetForce(force);
        }

        public override void SetAudioClip(AudioClip audioClip)
        {
            _weapon.SetAudioClip(audioClip);
        }
    }
}