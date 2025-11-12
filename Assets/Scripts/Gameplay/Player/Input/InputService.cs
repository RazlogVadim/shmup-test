using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player.Input
{
    public class InputService : IInputService
    {
        private readonly DefaultInputActions _actions;

        public Vector2 Direction => _actions.Player.Move.ReadValue<Vector2>();
        public bool IsAttacking => _actions.Player.Fire.IsPressed();

        public InputService() => _actions = new DefaultInputActions();

        public void EnableInputs() => _actions.Enable();
        public void DisableInputs() => _actions.Disable();
    }
}
