using Gameplay.Asteroids;
using Gameplay.Asteroids.Configs;
using Gameplay.Game;
using Gameplay.Game.WinConditions;
using Gameplay.Player;
using Gameplay.Player.Configs;
using Gameplay.Player.Input;
using Gameplay.Player.Weapon;
using Gameplay.Player.Weapon.Configs;
using Services.UI;
using StaticData;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private Canvas canvas;

        public override void InstallBindings()
        {
            BindAuxiliarySystems();
            BindGameSystems();
            BindAsteroidSystems();
            BindPlayerSystems();
        }

        private void BindAuxiliarySystems()
        {
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().WithArguments(canvas);
        }

        private void BindGameSystems()
        {
            Container.BindInterfacesAndSelfTo<AsteroidWinCondition>().AsSingle();   
            Container.BindInterfacesAndSelfTo<GameWinDecider>().AsSingle();   
            Container.BindInterfacesAndSelfTo<GameDirectorService>().AsSingle();
        }

        private void BindPlayerSystems()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<BulletSpawner>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerService>().AsSingle();

            Container
                .Bind<BulletConfig>()
                .FromScriptableObjectResource(ConfigPaths.BulletConfig)
                .AsSingle();

            Container
                .Bind<PlayerConfig>()
                .FromScriptableObjectResource(ConfigPaths.PlayerConfig)
                .AsSingle();
        }

        private void BindAsteroidSystems()
        {
            Container.BindInterfacesAndSelfTo<AsteroidSpawner>().AsSingle();

            Container
                .Bind<AsteroidConfig>()
                .FromScriptableObjectResource(ConfigPaths.AsteroidConfig)
                .AsSingle();
        }
    }
}
