using Gameplay.Player.Weapon.Components;
using UnityEngine;

namespace Gameplay.Player.Weapon.Configs
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Scriptable Objects/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        public BulletBrain BulletPrefab;
        public float CooldownSeconds = 1f;
        public float BaseSpeed = 5f;
    }
}