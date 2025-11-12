using LevelsMap.View;
using Services.AssetLoader.StaticData;
using Services.UI;
using UnityEngine;
using Zenject;

namespace LevelsMap
{
    public class LevelsSceneBootstrapper : MonoBehaviour
    {
        private IUIFactory _uiFactory;

        [Inject]
        private void Construct(IUIFactory uiFactory) => _uiFactory = uiFactory;

        private void Start() => _uiFactory.Create<LevelsMapView>(UIAssets.LevelsMapView);
    }
}
