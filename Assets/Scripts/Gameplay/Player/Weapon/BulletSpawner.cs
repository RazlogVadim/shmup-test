using Gameplay.Common;
using Gameplay.Player.Weapon.Components;
using Gameplay.Player.Weapon.Configs;
using R3;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Weapon
{
    public class BulletSpawner : IInitializable, IBulletSpawner
    {
        private TagHandle _asteroidTag;
        private float _lastBulletSpawned;
        private ObjectPool<BulletBrain> _bulletsPool;

        private readonly BulletConfig _config;

        public BulletSpawner(BulletConfig bulletConfig)
        {
            _config = bulletConfig;
            _asteroidTag = TagHandle.GetExistingTag("Asteroid");
        }

        public void Initialize() => _bulletsPool = new(_config.BulletPrefab, new GameObject("Bullets").transform, InitBullet);

        public void SpawnBullet(Vector3 origin)
        {
            if (Time.time - _lastBulletSpawned >= 1f)
            {
                var bullet = _bulletsPool.Pool.Get();
                bullet.SetPosition(origin);
                _lastBulletSpawned = Time.time;
            }
        }

        private void InitBullet(BulletBrain bullet)
        {
            bullet.SetBulletSpeed(_config.BaseSpeed);

            bullet.TriggerDetector.OnTriggerEntered
                .Subscribe(collider => OnBulletCollision(collider, bullet))
                .AddTo(bullet.gameObject);

            bullet.PosY
                .Subscribe(pos => BulletOutOfBounds(pos, bullet))
                .AddTo(bullet.gameObject);
        }

        private void BulletOutOfBounds(float pos, BulletBrain bullet)
        {
            if (pos > 8f)
                _bulletsPool.Pool.Release(bullet);
        }

        private void OnBulletCollision(Collider2D collider, BulletBrain bullet)
        {
            if (collider.CompareTag(_asteroidTag))
                _bulletsPool.Pool.Release(bullet);
        }
    }
}
