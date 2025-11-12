using Gameplay.Player.Components;
using Gameplay.Player.Configs;
using R3;
using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerService : IPlayerService, IDisposable
    {
        private IDisposable _disposable;
        private TagHandle _asteroidTag;

        public ReactiveProperty<int> PlayerHitPoints { get; }

        private readonly PlayerConfig _config;
        private readonly IInstantiator _instantiator;

        public PlayerService(PlayerConfig config, IInstantiator instantiator)
        {
            _config = config;
            _instantiator = instantiator;

            _asteroidTag = TagHandle.GetExistingTag("Asteroid");
            PlayerHitPoints = new ReactiveProperty<int>(_config.BaseHitPoints);
        }

        public void Initialize()
        {
            var player = SpawnPlayer();
            player.SetSpeed(_config.BaseSpeed);
            ObserveCollisions(player);
        }

        public void Dispose() => _disposable?.Dispose();

        private PlayerBrain SpawnPlayer() => _instantiator.InstantiatePrefabForComponent<PlayerBrain>(_config.PlayerPrefab);

        private void ObserveCollisions(PlayerBrain player)
        {
            _disposable = player.TriggerDetector.OnTriggerEntered
                .Subscribe(collision => OnPlayerCollision(collision, player))
                .AddTo(player.gameObject);
        }

        private void OnPlayerCollision(Collider2D collision, PlayerBrain player)
        {
            if (collision.gameObject.CompareTag(_asteroidTag) && --PlayerHitPoints.Value == 0)
                OnPlayerDied(player);
        }

        private void OnPlayerDied(PlayerBrain player) => UnityEngine.Object.Destroy(player.gameObject);
    }
}
