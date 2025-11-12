using Infrastructure.Services.SceneLoader;
using Infrastructure.StateMachine.Factory;
using Services.AssetLoader;
using Services.LevelGen;
using Services.LevelProgress;
using Services.ProgressService;
using Zenject;

namespace Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<StateMachine.StateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProgressService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourcesAssetLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelGenService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelsProgressService>().AsSingle();
        }
    }
}
