using System;

namespace Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader
    {
        void Load(int sceneIndex, Action onLoaded = null);
    }
}