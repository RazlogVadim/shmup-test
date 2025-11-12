using R3;
using UnityEngine;

namespace Gameplay.Common
{
    public class TriggerDetector : MonoBehaviour
    {
        public Subject<Collider2D> OnTriggerEntered = new();

        private void OnTriggerEnter2D(Collider2D collision) => 
            OnTriggerEntered.OnNext(collision);
    }
}
