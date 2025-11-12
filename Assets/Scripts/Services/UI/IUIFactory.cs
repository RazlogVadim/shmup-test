using UnityEngine;

namespace Services.UI
{
    public interface IUIFactory
    {
        GameObject Create(GameObject prefab);
        T Create<T>(string name) where T : Object;
    }
}