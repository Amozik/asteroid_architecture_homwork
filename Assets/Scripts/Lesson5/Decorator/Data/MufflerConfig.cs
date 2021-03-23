using UnityEngine;

namespace Lesson5.Decorator.Data
{
    [CreateAssetMenu(fileName = "MufflerConfig", menuName = "Configs/MufflerConfig", order = 0)]
    public class MufflerConfig : ScriptableObject
    {
        public AudioClip audioClip;
        public float volumeFireOn;
        public Transform barrelPosition;
        public GameObject muffler;
    }
}