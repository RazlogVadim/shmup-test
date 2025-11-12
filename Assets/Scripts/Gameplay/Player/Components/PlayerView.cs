using UnityEngine;

namespace Gameplay.Player.Components
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public Vector3 Size => spriteRenderer.bounds.size * transform.localScale.x;
    }
}
