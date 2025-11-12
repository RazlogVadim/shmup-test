using Gameplay.Game.WinConditions;
using R3;
using Services.LevelProgress;
using System;
using Zenject;

namespace Gameplay.Game
{
    public class GameWinDecider : IGameWinDecider, IInitializable, IDisposable
    {
        private readonly ILevelsProgressService _levelProgress;
        private readonly IGameWinCondition _condition;

        private IDisposable _disposable;

        public GameWinDecider(ILevelsProgressService levelProgress, IGameWinCondition condition)
        {
            _levelProgress = levelProgress;
            _condition = condition;
        }

        public void Initialize()
        {
            _disposable = _condition.OnGameWon
                .Subscribe(_ => _levelProgress.CompleteLevel(_levelProgress.CurrentLevel));
        }

        public void Dispose() => _disposable?.Dispose();
    }
}
