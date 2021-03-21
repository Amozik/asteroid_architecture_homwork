using System;
using General.Stats;
using UnityEngine;

namespace General.Enemies
{
    public interface IEnemy
    {
        Health Health { get; }
        event Action<GameObject> OnTriggerEnterChange;
    }
}