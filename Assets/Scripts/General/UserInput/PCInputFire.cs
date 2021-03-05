using System;
using General.Interfaces;
using General.Managers;
using UnityEngine;

namespace General
{
    public class PCInputFire : IUserButtonProxy
    {
        public event Action<bool> ButtonOnDown = delegate(bool b) {  };
        public void GetButtonDown()
        {
            ButtonOnDown.Invoke(Input.GetButtonDown(AxisManager.FIRE1));
        }
    }
}