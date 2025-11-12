using Gameplay.Game.View;
using Gameplay.Player;
using Gameplay.Player.Input;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using R3;
using Services.AssetLoader.StaticData;
using Services.LevelProgress;
using Services.UI;
using System;
using UnityEngine;

namespace Gameplay.Game
{
    public class GameDirectorService : IGameDirectorService, IDisposable
    {
        private IDisposable _disposable;

        private readonly IStateMachine _stateMachine;
        private readonly ILevelsProgressService _levelStatusService;
        private readonly IPlayerService _playerService;
        private readonly IUIFactory _uiFactory;
        private readonly IInputService _inputService;

        public GameDirectorService(
            IStateMachine stateMachine,
            ILevelsProgressService levelStatusService,
            IPlayerService playerService,
            IUIFactory uiFactory,
            IInputService inputService)
        {
            _stateMachine = stateMachine;
            _levelStatusService = levelStatusService;
            _playerService = playerService;
            _uiFactory = uiFactory;
            _inputService = inputService;
        }

        public void Initialize()
        {
            var d1 = _levelStatusService.OnLevelComplete
                .Subscribe(_ => EndGame(true));

            var d2 = _playerService.PlayerHitPoints
                .Where(hp => hp == 0)
                .Subscribe(_ => EndGame(false));

            _disposable = Disposable.Combine(d1, d2);

            SetPaused(false);
        }

        public void Dispose() => _disposable?.Dispose();

        private void EndGame(bool win)
        {
            _inputService.DisableInputs();
            SetPaused(true);

            ShowWindow(win);
        }

        private void ShowWindow(bool win)
        {
            var view = _uiFactory.Create<GameEndedView>(UIAssets.GameEndedView);
            view.SetDescription(win);
            view.SetButtonActions(RestartLevel, LeaveLevel);
        }

        private void LeaveLevel() => _stateMachine.Enter<LoadLevelsMapState>();

        private void RestartLevel() => _stateMachine.Enter<LoadLevelState, int>(_levelStatusService.CurrentLevel);

        private void SetPaused(bool isPaused) => Time.timeScale = isPaused ? 0f : 1f;
    }
}
