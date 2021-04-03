using UnityEngine;

namespace Lesson5.Decorator
{
    internal class TelescopicSight : ITelescopicSight
    {
        public float SightForce { get; }
        public GameObject SightInstance { get; }

        public TelescopicSight(GameObject sightInstance, float sightForce)
        {
            SightInstance = sightInstance;
            SightForce = sightForce;
        }
    }
}