using UnityEngine;

namespace Gameplay.Asteroids.Components
{
    public class AsteroidView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetColor(Color color) => spriteRenderer.color = color;
    }
}
