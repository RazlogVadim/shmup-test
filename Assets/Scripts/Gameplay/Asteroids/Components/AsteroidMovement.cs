using R3;
using UnityEngine;

namespace Gameplay.Asteroids.Components
{
    public class AsteroidMovement : MonoBehaviour
    {
        private float _rotationPower;
        private float _speedModifier;

        public ReactiveProperty<float> PosY = new();

        private void Update()
        {
            transform.Translate(_speedModifier * Time.deltaTime * Vector3.down, Space.World);
            transform.Rotate(_rotationPower * Time.deltaTime * Vector3.forward);
            PosY.Value = transform.localPosition.y;
        }

        public void SetModifiers(float rotation, float speed)
        {
            _rotationPower = rotation;
            _speedModifier = speed;
        }
    }
}
