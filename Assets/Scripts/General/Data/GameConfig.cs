using General.Player;
using UnityEngine;

namespace General
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        public PlayerConfig playerConfig;
        public EnemiesConfig enemiesConfig;
        public UiConfig uiConfig;
    }
}