using Gameplay.Player.Input;
using Gameplay.Player.Weapon;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Components
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;

        private IInputService _inputService;
        private IBulletSpawner _bulletSpawner;

        [Inject]
        private void Construct(IInputService inputService, IBulletSpawner bulletSpawner)
        {
            _inputService = inputService;
            _bulletSpawner = bulletSpawner;
        }

        private void Update()
        {
            if (_inputService.IsAttacking)
                _bulletSpawner.SpawnBullet(bulletSpawnPoint.position);
        }
    }
}
