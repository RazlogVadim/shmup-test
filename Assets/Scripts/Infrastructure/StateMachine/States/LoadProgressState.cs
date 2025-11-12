using Services.ProgressService;

namespace Infrastructure.StateMachine.States
{
    public class LoadProgressState : IState
    {
        private readonly IProgressService _progressService;
        private readonly IStateMachine _stateMachine;

        public LoadProgressState(IProgressService progressService, IStateMachine stateMachine)
        {
            _progressService = progressService;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _progressService.LoadGameProgress();
            _progressService.InformReaders();

            Next();
        }

        private void Next() => _stateMachine.Enter<LoadLevelsMapState>();
    }
}
