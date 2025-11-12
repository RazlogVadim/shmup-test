using R3;
using UnityEngine;

namespace Gameplay.Player.Weapon.Components
{
    public class BulletMovement : MonoBehaviour
    {
        private float _bulletSpeed = 5f;

        public ReactiveProperty<float> PosY { get; } = new();

        private void Update()
        {
            transform.localPosition += _bulletSpeed * Time.deltaTime * Vector3.up;
            PosY.Value = transform.localPosition.y;
        }

        public void SetBulletSpeed(float speed) => _bulletSpeed = speed;
    }
}
