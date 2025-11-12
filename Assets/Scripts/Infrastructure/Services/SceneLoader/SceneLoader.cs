using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public void Load(int sceneIndex, Action onLoaded = null) =>
            LoadAsync(sceneIndex, onLoaded).Forget();

        private async UniTask LoadAsync(int sceneIndex, Action onLoaded)
        {
            var process = SceneManager.LoadSceneAsync(sceneIndex);
            await UniTask.WaitUntil(() => process.isDone);
            onLoaded?.Invoke();
        }
    }
}
