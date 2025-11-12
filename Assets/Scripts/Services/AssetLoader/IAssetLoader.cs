using UnityEngine;

namespace Services.AssetLoader
{
    public interface IAssetLoader
    {
        T LoadAsset<T>(string name) where T : Object;
    }
}