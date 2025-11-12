using Services.AssetLoader;
using UnityEngine;
using Zenject;

namespace Services.UI
{
    public class UIFactory : IUIFactory
    {
        private readonly Canvas _canvas;
        private readonly IInstantiator _instantiator;
        private readonly IAssetLoader _assetLoader;

        public UIFactory(Canvas canvas, IInstantiator instantiator, IAssetLoader assetLoader)
        {
            _canvas = canvas;
            _instantiator = instantiator;
            _assetLoader = assetLoader;
        }

        public T Create<T>(string name) where T : Object =>
            _instantiator.InstantiatePrefabForComponent<T>(_assetLoader.LoadAsset<T>(name), _canvas.gameObject.transform);

        public GameObject Create(GameObject prefab) =>
            _instantiator.InstantiatePrefab(prefab, _canvas.gameObject.transform);
    }
}
