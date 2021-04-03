using UnityEngine;

namespace Lesson5.Decorator.Data
{
    [CreateAssetMenu(fileName = "TelescopicSightConfig", menuName = "Configs/TelescopicSightConfig", order = 0)]
    public class TelescopicSightConfig : ScriptableObject
    {
        public float force;
        public Transform sightPosition;
        public GameObject sight;
    }
}