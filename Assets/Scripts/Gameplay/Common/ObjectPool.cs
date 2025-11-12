using UnityEngine;
using UnityEngine.Pool;

namespace Gameplay.Common
{
    public class ObjectPool<TComponent> where TComponent : Component
    {
        public IObjectPool<TComponent> Pool { get; }

        private readonly TComponent _prefab;
        private readonly Transform _parent;
        private readonly System.Action<TComponent> _afterCreate;

        public ObjectPool(TComponent prefab, Transform parent, System.Action<TComponent> afterCreate = null)
        {
            _prefab = prefab;
            _parent = parent;
            _afterCreate = afterCreate;

            Pool = new UnityEngine.Pool.ObjectPool<TComponent>(Create, Get, Release, Destroy, true, 10, 50);
        }

        private TComponent Create()
        {
            var obj = Object.Instantiate(_prefab, _parent);
            _afterCreate?.Invoke(obj);
            return obj;
        }

        private void Get(TComponent component) => component.gameObject.SetActive(true);

        private void Release(TComponent component) => component.gameObject.SetActive(false);

        private void Destroy(TComponent component) => Object.Destroy(component.gameObject);
    }
}
