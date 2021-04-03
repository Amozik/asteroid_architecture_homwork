using System;
using General.Interfaces;
using General.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General.Controllers.UI
{
    public enum StateUI
    {
        None     = 0,
        PauseMenu = 1,
        EndGame = 2,
    }
    
    public class UiController : ICleanup
    {
        private ShowWindowCommand _showWindowCommand;
        private IUserButtonProxy _pauseInput;
        private Action _onDeathPlayer;

        public UiController(PauseMenu pauseMenu, EndGame endGame, IUserButtonProxy pauseInput, Action onDeathPlayer)
        {
            pauseMenu.RestartGame = RestartGame;
            pauseMenu.ResumeGame = ResumeGame;
            endGame.RestartGame = RestartGame;
            
            pauseMenu.Initialization();
            endGame.Initialization();

            _pauseInput = pauseInput;
            pauseInput.ButtonOnDown += OnPauseClick;
            _onDeathPlayer += OnDeathPlayer;
            
            _showWindowCommand = new ShowWindowCommand(pauseMenu, endGame);
            _showWindowCommand.Execute(StateUI.None);
        }
        
        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            ResumeGame();
        }
        
        private void ResumeGame()
        {
            Time.timeScale = 1.0f;
        }
        
        private void OnPauseClick(bool value)
        {
            if (!value) return;

            Time.timeScale = 0f;
            
            _showWindowCommand.Execute(StateUI.PauseMenu);
        }
        
        private void OnDeathPlayer()
        {
            Time.timeScale = 0f;
            _showWindowCommand.Execute(StateUI.EndGame);
        }

        public void Cleanup()
        {
            _pauseInput.ButtonOnDown += OnPauseClick;
            _onDeathPlayer -= OnDeathPlayer;
        }
    }
}