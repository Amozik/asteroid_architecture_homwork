using UnityEngine;
using UnityEngine.UI;

namespace General.UI
{
    public class DisplayScore
    {
        private Text _text;

        public DisplayScore(GameObject scoreElement)
        {
            _text = scoreElement.GetComponentInChildren<Text>();
        }
        
        public void Display(int score)
        {
            _text.text = NumbersInterpreter.Format(score);
        }
    }
}