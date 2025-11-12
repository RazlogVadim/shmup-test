using Infrastructure.Services.SceneLoader;
using Services.LevelProgress;

namespace Infrastructure.StateMachine.States
{
    public class LoadLevelState : IPayloadedState<int>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILevelsProgressService _levelStatusService;

        public LoadLevelState(ISceneLoader sceneLoader, ILevelsProgressService levelStatusService)
        {
            _sceneLoader = sceneLoader;
            _levelStatusService = levelStatusService;
        }

        public void Enter(int level)
        {
            _levelStatusService.CurrentLevel = level;
            _sceneLoader.Load(2);
        }
    }
}
