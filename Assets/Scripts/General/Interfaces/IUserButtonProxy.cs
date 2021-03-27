using System;

namespace General.Interfaces
{
    public interface IUserButtonProxy
    {
        event Action<bool> ButtonOnDown;
        event Action<bool> ButtonOnUp;
        void GetButtonDown();
        void GetButtonUp();
    }
}