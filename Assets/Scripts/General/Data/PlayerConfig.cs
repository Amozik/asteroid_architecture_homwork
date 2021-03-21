using General.Player;
using UnityEngine;

namespace General
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public PlayerBase playerPrefab;
        public float playerSpeed;
        public float playerHP;
        public Rigidbody2D bullet;
        public Sprite bulletSprite;
        public float bulletForce;
    }
}