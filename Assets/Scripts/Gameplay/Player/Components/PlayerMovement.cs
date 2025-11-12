using Gameplay.Player.Input;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Components
{
    public class PlayerMovement : MonoBehaviour
    {
        private float _playerSpeed = 1f;
        private float _xBoundary;
        private Vector2 _yBoundaries;
        private Camera _camera;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService) => _inputService = inputService;

        private void Awake() => _camera = Camera.main;

        private void Update()
        {
            Vector2 direction = _inputService.Direction;

            Vector3 newPos = transform.localPosition + _playerSpeed * Time.deltaTime * (Vector3)direction;
            newPos.x = Mathf.Clamp(newPos.x, -_xBoundary, _xBoundary);
            newPos.y = Mathf.Clamp(newPos.y, _yBoundaries.x, _yBoundaries.y);

            transform.localPosition = newPos;
        }

        public void UpdateBoundaries(Vector3 playerSize)
        {
            var rightBottom = _camera.ViewportToWorldPoint(Vector2.right);
            var leftUpper = _camera.ViewportToWorldPoint(Vector2.up);

            _xBoundary = rightBottom.x - playerSize.x / 2f;
            _yBoundaries = new Vector2(rightBottom.y + playerSize.y / 2f, leftUpper.y - playerSize.y);
        }

        public void SetSpeed(float speed) => _playerSpeed = speed;
    }
}
