using General.Enemies;
using General.Interfaces;
using General.MessageBroker;
using General.UI;
using UnityEngine;

namespace General.Controllers.UI
{
    public class ScoreController : ICleanup
    {
        private DisplayScore _displayScore;
        private int _points = 0;

        public ScoreController(GameObject scoreElement)
        {
            _displayScore = new DisplayScore(scoreElement);
            
            SimpleMessageBroker.Subscribe<EnemyDestroyMessage>(OnEnemyDestroy);
        }

        private void OnEnemyDestroy(EnemyDestroyMessage message)
        {
            _points += message.points;
            
            _displayScore.Display(_points);
        }

        public void Cleanup()
        {
            SimpleMessageBroker.Unsubscribe<EnemyDestroyMessage>(OnEnemyDestroy);
        }
    }
}