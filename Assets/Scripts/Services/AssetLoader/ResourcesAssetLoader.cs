using UnityEngine;

namespace Services.AssetLoader
{
    public class ResourcesAssetLoader : IAssetLoader
    {
        public T LoadAsset<T>(string name) where T : Object =>
            Resources.Load<T>(name);
    }
}
