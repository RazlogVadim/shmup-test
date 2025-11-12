using Gameplay.Asteroids.Components;
using Gameplay.Asteroids.Configs;
using Gameplay.Common;
using R3;
using Services.LevelGen;
using Services.LevelProgress;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Asteroids
{
    public class AsteroidSpawner : IDisposable, IAsteroidSpawner
    {
        private const float UpperBoundary = 8f;
        private const float BottomBoundary = -6f;
        private const float SideBoundary = 2.5f;

        private TagHandle _bulletTag;
        private TagHandle _playerTag;

        private LevelGenData _data;
        private IDisposable _disposable;
        private ObjectPool<AsteroidBrain> _asteroidPool;

        private readonly AsteroidConfig _config;
        private readonly ILevelsProgressService _levelStatusService;

        public ReactiveProperty<int> AsteroidsDestroyed { get; } = new();

        public AsteroidSpawner(AsteroidConfig config, ILevelsProgressService levelStatusService)
        {
            _config = config;
            _levelStatusService = levelStatusService;

            _bulletTag = TagHandle.GetExistingTag("Bullet");
            _playerTag = TagHandle.GetExistingTag("Player");
        }

        public void Initialize()
        {
            _asteroidPool =
                new(_config.AsteroidPrefab, new GameObject("Asteroids").transform, CreateAsteroid);

            _data = _levelStatusService.GetGenData(_levelStatusService.CurrentLevel);

            SpawnAsteroids();
        }

        public void Dispose() => _disposable?.Dispose();

        private void SpawnAsteroids()
        {
            _disposable = Observable
                .Interval(TimeSpan.FromSeconds(_data.SpawnInterval))
                .Subscribe(SpawnAsteroid);
        }

        private void SpawnAsteroid(Unit _)
        {
            AsteroidBrain asteroid = _asteroidPool.Pool.Get();
            SetPositionAndScale(asteroid);
            SetModifiers(asteroid);
        }

        private void SetModifiers(AsteroidBrain asteroid)
        {
            asteroid.SetMovementModifiers(
                Random.Range(_config.RotationPowerRange.x, _config.RotationPowerRange.y),
                Random.Range(_config.SpeedModifierRange.x, _config.SpeedModifierRange.y));
        }

        private void SetPositionAndScale(AsteroidBrain asteroid)
        {
            asteroid.SetPosition(new Vector3(
                Random.Range(-SideBoundary, SideBoundary),
                UpperBoundary,
                0));

            asteroid.SetScale(Random.Range(_config.ScaleRange.x, _config.ScaleRange.y));
        }

        private void CreateAsteroid(AsteroidBrain asteroid)
        {
            asteroid.gameObject.SetActive(false);
            asteroid.SetColor(_data.AsteroidColor);

            asteroid.PosY
                .Subscribe(y => AsteroidOutOfBounds(asteroid, y))
                .AddTo(asteroid.gameObject);

            asteroid.TriggerDetector.OnTriggerEntered
                .Subscribe(collision => OnAsteroidCollision(asteroid, collision))
                .AddTo(asteroid.gameObject);
        }

        private void AsteroidOutOfBounds(AsteroidBrain asteroid, float posY)
        {
            if (posY < BottomBoundary)
            {
                _asteroidPool.Pool.Release(asteroid);
                asteroid.SetPosition(Vector3.zero);
            }
        }

        private void OnAsteroidCollision(AsteroidBrain asteroid, Collider2D collision)
        {
            if (collision.CompareTag(_bulletTag) || collision.CompareTag(_playerTag))
                _asteroidPool.Pool.Release(asteroid);

            if (collision.CompareTag(_bulletTag))
                AsteroidsDestroyed.Value++;
        }
    }
}
