using UnityEngine;

namespace Lesson5.Decorator.Data
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/WeaponConfig", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        public Rigidbody2D bullet;
        public Transform barrelPosition;
        public AudioSource audioSource;
        public AudioClip audioClip;
    }
}