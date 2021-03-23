using Lesson5.Decorator.Data;
using UnityEngine;

namespace Lesson5.Decorator
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;

        [SerializeField] 
        private WeaponConfig _weaponConfig;
        [SerializeField] 
        private MufflerConfig _muflerConfig;
        [SerializeField] 
        private TelescopicSightConfig _sightConfig;
        
        private void Start()
        {
            IAmmunition ammunition = new Bullet(_weaponConfig.bullet, 3.0f);
            var weapon = new Weapon(ammunition, _weaponConfig.barrelPosition, 999.0f, _weaponConfig.audioSource, _weaponConfig.audioClip);

            var muffler = new Muffler(_muflerConfig.audioClip, _muflerConfig.volumeFireOn, _weaponConfig.barrelPosition, _muflerConfig.muffler);
            
            ModificationWeapon modificationWithMuffler = new ModificationMuffler(_weaponConfig.audioSource, muffler, _muflerConfig.barrelPosition.position);
            modificationWithMuffler.ApplyModification(weapon);
            
            var sight = new TelescopicSight(_sightConfig.sight, _sightConfig.force);
            
            ModificationWeapon modificationWeapon = new ModificationSight(sight, _sightConfig.sightPosition.position);
            modificationWeapon.ApplyModification(modificationWithMuffler);
            
            _fire = modificationWeapon;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
        }
    }
}