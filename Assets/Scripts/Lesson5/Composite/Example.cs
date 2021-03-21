using System;
using UnityEngine;

namespace Lesson5.Composite
{
    public class Example : MonoBehaviour
    {
        private void Start()
        {
            var factory = new CompositeFactory();
            var enemies = factory.CreateEnemies();
        }
    }
}