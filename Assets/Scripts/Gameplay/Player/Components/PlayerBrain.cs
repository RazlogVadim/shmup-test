using Gameplay.Common;
using UnityEngine;

namespace Gameplay.Player.Components
{
    public class PlayerBrain : MonoBehaviour
    {
        [SerializeField] private PlayerView playerView;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private TriggerDetector triggerDetector;

        public TriggerDetector TriggerDetector => triggerDetector;

        private void Start() => playerMovement.UpdateBoundaries(playerView.Size);

        public void SetSpeed(float speed) => playerMovement.SetSpeed(speed);
    }
}
