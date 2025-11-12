using Gameplay.Common;
using R3;
using UnityEngine;

namespace Gameplay.Asteroids.Components
{
    public class AsteroidBrain : MonoBehaviour
    {
        [SerializeField] private AsteroidMovement movement;
        [SerializeField] private AsteroidView view;
        [SerializeField] private TriggerDetector triggerDetector;

        public TriggerDetector TriggerDetector => triggerDetector;
        public ReactiveProperty<float> PosY => movement.PosY;

        public void SetMovementModifiers(float rotation, float speed) => 
            movement.SetModifiers(rotation, speed);

        public void SetPosition(Vector3 pos) => transform.localPosition = pos;

        public void SetScale(float scale) => transform.localScale = scale * Vector3.one;

        public void SetColor(Color color) => view.SetColor(color);
    }
}
