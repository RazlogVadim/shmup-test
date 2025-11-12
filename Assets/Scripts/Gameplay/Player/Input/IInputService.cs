using UnityEngine;

namespace Gameplay.Player.Input
{
    public interface IInputService
    {
        Vector2 Direction { get; }
        bool IsAttacking { get; }

        void DisableInputs();
        void EnableInputs();
    }
}