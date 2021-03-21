using UnityEngine;

namespace General.Interfaces
{
    public interface IViewService
    {
        GameObject Create(GameObject prefab);
        void Destroy(GameObject prefab, GameObject gameObject);
    }
}