using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Factory;
using Infrastructure.StateMachine.States;
using Services.ProgressService;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;
        private IProgressService _progressService;

        [Inject]
        private void Construct(IStateMachine stateMachine, IStateFactory stateFactory, IProgressService progressService)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _progressService = progressService;
        }

        private void Awake() => DontDestroyOnLoad(gameObject);

        private void Start()
        {
            _stateMachine.Register(_stateFactory.Create<LoadProgressState>());
            _stateMachine.Register(_stateFactory.Create<LoadLevelsMapState>());
            _stateMachine.Register(_stateFactory.Create<LoadLevelState>());

            _stateMachine.Enter<LoadProgressState>();
        }

        private void OnApplicationQuit() => _progressService.SaveGameProgress();
    }
}
