using Gameplay.Asteroids;
using R3;
using System;
using Zenject;

namespace Gameplay.Game.WinConditions
{
    public class AsteroidWinCondition : IGameWinCondition, IInitializable, IDisposable
    {
        private const int AmountToWin = 5;

        private readonly IAsteroidSpawner _asteroidSpawner;

        private IDisposable _disposable;

        public Subject<Unit> OnGameWon { get; } = new();

        public AsteroidWinCondition(IAsteroidSpawner asteroidSpawner) => _asteroidSpawner = asteroidSpawner;

        public void Initialize()
        {
            _disposable = _asteroidSpawner.AsteroidsDestroyed
                .Where(destroyed => destroyed >= AmountToWin)
                .Take(1)
                .Subscribe(_ => OnGameWon.OnNext(Unit.Default));
        }

        public void Dispose() => _disposable?.Dispose();
    }
}
