using General.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace General.UI
{
    public class DisplayDestroyedEnemies
    {
        private Text _text;

        public DisplayDestroyedEnemies(GameObject textElement)
        {
            _text = textElement.GetComponentInChildren<Text>();
        }

        public void Add(Enemy enemy)
        {
            enemy.OnDestroy += OnDestroyEnemy;
        }
        
        public void Remove(Enemy enemy)
        {
            enemy.OnDestroy -= OnDestroyEnemy;
        }
        
        public void OnDestroyEnemy(string name)
        {
            _text.text = $"You destroyed {name}";
        }
        
    }
}