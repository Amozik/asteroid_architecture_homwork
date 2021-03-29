using System;
using General.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace General.UI
{
    public class EndGame : BaseUi, IInitialization
    {
        public Action RestartGame;
        
        [SerializeField] 
        private Button _restartBtn;
        
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
            _restartBtn.onClick.AddListener(OnRestartClick);
        }
        
        private void OnRestartClick()
        {
            RestartGame?.Invoke();
        }
    }
}