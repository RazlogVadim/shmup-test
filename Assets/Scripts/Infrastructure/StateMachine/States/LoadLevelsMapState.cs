using Infrastructure.Services.SceneLoader;

namespace Infrastructure.StateMachine.States
{
    public class LoadLevelsMapState : IState
    {
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelsMapState(ISceneLoader sceneLoader) => _sceneLoader = sceneLoader;

        public void Enter() => _sceneLoader.Load(1);
    }
}
