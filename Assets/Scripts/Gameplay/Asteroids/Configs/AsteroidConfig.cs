using Gameplay.Asteroids.Components;
using UnityEngine;

namespace Gameplay.Asteroids.Configs
{
    [CreateAssetMenu(fileName = "AsteroidConfig", menuName = "Scriptable Objects/AsteroidConfig")]
    public class AsteroidConfig : ScriptableObject
    {
        public AsteroidBrain AsteroidPrefab;
        public Vector2 RotationPowerRange;
        public Vector2 SpeedModifierRange;
        public Vector2 ScaleRange;
    }
}