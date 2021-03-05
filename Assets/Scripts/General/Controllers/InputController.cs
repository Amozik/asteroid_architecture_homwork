﻿using General.Interfaces;
using UnityEngine;

namespace General
{
    public class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserButtonProxy _button;
        
        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, IUserButtonProxy buttonInput)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _button = buttonInput;
        }
        
        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _button.GetButtonDown();
        }
    }
}