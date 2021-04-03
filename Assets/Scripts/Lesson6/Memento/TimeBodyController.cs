using System.Collections.Generic;
using General.Interfaces;
using UnityEngine;

namespace Lesson6.Memento
{
    public class TimeBodyController : IInitialization, IExecute, ICleanup
    {
        private List<GameObject> _gameObjects;
        private float _recordTime = 5f;
        private IUserButtonProxy _keyInputProxy;

        private Dictionary<(Transform transform, Rigidbody2D rigidbody), List<PointInTime>> _objectsPointers;
        private bool _isRewinding;

        public TimeBodyController(List<GameObject> gameObjects, float recordTime, IUserButtonProxy keyInputProxy)
        {
            _gameObjects = gameObjects;
            _recordTime = recordTime;
            _keyInputProxy = keyInputProxy;
            _keyInputProxy.ButtonOnDown += StartRewind;
            _keyInputProxy.ButtonOnUp += StopRewind;
        }

        public void Initialization()
        {
            foreach (var gameObject in _gameObjects)
            {
                var transform = gameObject.transform;
                var rigidbody = gameObject.GetComponent<Rigidbody2D>();
                
                if (!rigidbody) 
                    continue;
                
                _objectsPointers.Add((transform, rigidbody), new List<PointInTime>());
            }
        }
        
        public void Execute(float deltaTime)
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }
        
        private void StartRewind(bool value)
        {
            if (!value) return;
            
            _isRewinding = true;
            
            foreach (var obj in _objectsPointers.Keys)
            {
                obj.rigidbody.isKinematic = true;
            }
        }
        
        private void Rewind ()
        {
            foreach (var objectPointers in _objectsPointers)
            {
                var pointers = objectPointers.Value;
                var transform = objectPointers.Key.transform;
                
                if (pointers.Count > 1)
                {
                    var pointInTime = pointers[0];
                    transform.position = pointInTime.Position;
                    transform.rotation = pointInTime.Rotation;
                    pointers.RemoveAt(0);
                } 
                else
                {
                    var pointInTime = pointers[0];
                    transform.position = pointInTime.Position;
                    transform.rotation = pointInTime.Rotation;
                    StopRewind(true);
                }
            }
        }
        
        private void Record()
        {
            foreach (var objectPointers in _objectsPointers)
            {
                var pointers = objectPointers.Value;
                var transform = objectPointers.Key.transform;
                var rigidbody = objectPointers.Key.rigidbody;
                
                if (pointers.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
                {
                    pointers.RemoveAt(pointers.Count - 1);
                }

                pointers.Insert(0, new PointInTime(transform.position, transform.rotation, rigidbody.velocity, rigidbody.angularVelocity));
            }
        }

        private void StopRewind(bool value)
        {
            if (!value) return;
            
            _isRewinding = false;
            
            foreach (var objectPointers in _objectsPointers)
            {
                var rigidbody = objectPointers.Key.rigidbody;
                var point = objectPointers.Value[0];
                rigidbody.isKinematic = false; rigidbody.velocity = point.Velocity;
                rigidbody.angularVelocity = point.AngularVelocity;
            }
        }

        public void Cleanup()
        {
            _keyInputProxy.ButtonOnDown -= StartRewind;
            _keyInputProxy.ButtonOnUp -= StopRewind;
        }
    }
}