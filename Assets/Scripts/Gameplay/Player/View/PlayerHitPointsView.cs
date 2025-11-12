using Cysharp.Threading.Tasks;
using Gameplay.Player;
using R3;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.View
{
    public class PlayerHitPointsView : MonoBehaviour
    {
        [SerializeField] private GameObject hitPointPrefab;

        private GameObject[] _hitPoints;
        private IPlayerService _playerService;

        [Inject]
        private void Construct(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        private void Start()
        {
            CreateHitPoints();

            _playerService.PlayerHitPoints
                .Subscribe(DisplayHitPoints)
                .AddTo(this);
        }

        private void DisplayHitPoints(int hitPoints)
        {
            for (int i = 0; i < _hitPoints.Length; i++)
                _hitPoints[i].SetActive(i < hitPoints);

            gameObject.SetActive(hitPoints != 0);
        }

        private void CreateHitPoints()
        {
            int amount = _playerService.PlayerHitPoints.Value;
            _hitPoints = new GameObject[amount];
            for (int i = 0; i < amount; i++)
                _hitPoints[i] = Instantiate(hitPointPrefab, transform);
        }
    }
}
