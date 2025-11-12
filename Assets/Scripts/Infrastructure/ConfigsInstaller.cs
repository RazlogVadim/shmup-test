using Configs;
using StaticData;
using Zenject;

namespace Infrastructure
{
    public class ConfigsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<LevelsConfig>()
                .FromScriptableObjectResource(ConfigPaths.LevelsConfig)
                .AsSingle();
        }
    }
}
