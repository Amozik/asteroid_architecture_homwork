using UnityEngine;

namespace Lesson5.Decorator
{
    internal sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;
        private GameObject _mufflerObject;
        private Weapon _weapon;

        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Vector3 mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            _mufflerObject = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.identity);
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            _weapon = weapon;
            return weapon;
        }

        protected override void RemoveModification()
        {
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            _weapon.SetAudioClip(_muffler.AudioClipMuffler);
            _weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            Object.Destroy(_mufflerObject);
        }
    }
}