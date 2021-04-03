using System.Collections.Generic;
using General.Controllers.UI;

namespace General.UI
{
    public class ShowWindowCommand
    {
        private PauseMenu _pauseMenu;
        private EndGame _endGame;
        private BaseUi _currentWindow;
        private readonly Stack<StateUI> _stateUi = new Stack<StateUI>();

        public ShowWindowCommand(PauseMenu pauseMenu, EndGame endGame)
        {
            _pauseMenu = pauseMenu;
            _endGame = endGame;
        }
        
        public void Execute(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }

            switch (stateUI)
            {
                case StateUI.EndGame:
                    _currentWindow = _pauseMenu;
                    break;

                case StateUI.PauseMenu:
                    _currentWindow =_endGame;
                    break;

                default:
                    _currentWindow = null;
                    _pauseMenu.Cancel();
                    _endGame.Cancel();
                    break;
            }

            _currentWindow.Execute();
            if (isSave)
            {
                _stateUi.Push(stateUI);
            }
        }
    }
}