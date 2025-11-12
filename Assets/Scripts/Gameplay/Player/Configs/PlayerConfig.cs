using UnityEngine;

namespace Gameplay.Player.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Objects/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public int BaseHitPoints = 3;
        public float BaseSpeed = 4f;
    }
}