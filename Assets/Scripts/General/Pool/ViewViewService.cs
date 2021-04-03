using System.Collections.Generic;
using General.Interfaces;
using UnityEngine;

namespace General.Pool
{
    internal sealed class ViewViewService : IViewService
    {
        private readonly Dictionary<int, ObjectPool> _viewCache = new Dictionary<int, ObjectPool>(12);
        
        public GameObject Create(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.GetInstanceID(), out var viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.GetInstanceID()] = viewPool;
            }

            return viewPool.Pop();
        }

        public void Destroy(GameObject prefab, GameObject gameObject)
        {
            _viewCache[prefab.GetInstanceID()].Push(gameObject); 
        }
    }
}