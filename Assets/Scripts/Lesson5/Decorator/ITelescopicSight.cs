using UnityEngine;

namespace Lesson5.Decorator
{
    public interface ITelescopicSight
    {
        float SightForce { get; }
        GameObject SightInstance { get; }
    }
}