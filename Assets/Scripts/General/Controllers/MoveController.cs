using General.Interfaces;
using General.Player;

namespace General.Controllers
{
    public class MoveController : IExecute, ICleanup
    {
        private readonly IMove _move;
        private float _horizontal;
        private float _vertical;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        
        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            IMove move)
        {
            _move = move;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }
        
        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }
        
        public void Execute(float deltaTime)
        {
            _move.Move(_horizontal, _vertical, deltaTime);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
        
    }
}