using Gameplay.Asteroids;
using Gameplay.Game;
using Gameplay.Player;
using Gameplay.Player.Input;
using Gameplay.Player.View;
using Services.AssetLoader.StaticData;
using Services.UI;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameplaySceneBootstrapper : MonoBehaviour
    {
        private IAsteroidSpawner _asteroidService;
        private IPlayerService _playerService;
        private IInputService _inputService;
        private IUIFactory _uiFactory;
        private IGameDirectorService _gameDirector;

        [Inject]
        private void Construct(
            IAsteroidSpawner asteroidService, 
            IPlayerService playerService, 
            IInputService inputService, 
            IUIFactory uiFactory, 
            IGameDirectorService gameDirector)
        {
            _asteroidService = asteroidService;
            _playerService = playerService;
            _inputService = inputService;
            _uiFactory = uiFactory;
            _gameDirector = gameDirector;
        }

        private void Start()
        {
            Initialize();
            CreateUI();
        }

        private void Initialize()
        {
            _gameDirector.Initialize();
            _inputService.EnableInputs();

            _playerService.Initialize();
            _asteroidService.Initialize();
        }

        private void CreateUI()
        {
            _uiFactory.Create<PlayerHitPointsView>(UIAssets.PlayerHitPointsView);
        }
    }
}
