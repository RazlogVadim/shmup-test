using Gameplay.Common;
using R3;
using UnityEngine;

namespace Gameplay.Player.Weapon.Components
{
    public class BulletBrain : MonoBehaviour
    {
        [SerializeField] private BulletMovement bulletMovement;
        [SerializeField] private TriggerDetector triggerDetector;

        public TriggerDetector TriggerDetector => triggerDetector;
        public ReactiveProperty<float> PosY => bulletMovement.PosY;

        public void SetPosition(Vector3 pos) => transform.position = pos;

        public void SetBulletSpeed(float speed) => bulletMovement.SetBulletSpeed(speed);
    }
}
