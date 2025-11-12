using Services.UI;
using UnityEngine;
using Zenject;

namespace LevelsMap
{
    public class LevelsSceneInstaller : MonoInstaller
    {
        [SerializeField] private Canvas canvas;

        public override void InstallBindings() => Container
            .BindInterfacesAndSelfTo<UIFactory>()
            .AsSingle()
            .WithArguments(canvas);
    }
}
