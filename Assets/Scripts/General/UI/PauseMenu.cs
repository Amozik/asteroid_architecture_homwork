using System;
using General.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace General.UI
{
    public class PauseMenu : BaseUi, IInitialization
    {
        [SerializeField] 
        private Button _closeBtn;
        [SerializeField] 
        private Button _restartBtn;
        
        public Action RestartGame;
        public Action ResumeGame;

        public override void Execute()
        {
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }

        public void Initialization()
        {
            gameObject.SetActive(false);
            _closeBtn.onClick.AddListener(OnCloseClick);
            _restartBtn.onClick.AddListener(OnRestartClick);
        }
        
        private void OnCloseClick()
        {
            ResumeGame?.Invoke();
        }
        
        private void OnRestartClick()
        {
            RestartGame?.Invoke();
        }
    }
}