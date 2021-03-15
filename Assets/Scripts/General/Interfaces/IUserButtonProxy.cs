using System;

namespace General.Interfaces
{
    public interface IUserButtonProxy
    {
        event Action<bool> ButtonOnDown;
        void GetButtonDown();
    }
}