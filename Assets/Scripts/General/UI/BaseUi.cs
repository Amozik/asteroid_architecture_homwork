using UnityEngine;

namespace General.UI
{
    public abstract class BaseUi : MonoBehaviour
    {
        public abstract void Execute();  
        public abstract void Cancel();
    }
}