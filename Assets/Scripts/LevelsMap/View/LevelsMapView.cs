using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using R3;
using Services.LevelProgress;
using UnityEngine;
using Zenject;

namespace LevelsMap.View
{
    public class LevelsMapView : MonoBehaviour
    {
        [SerializeField] private LevelButtonView[] levelButtons;

        private IStateMachine _stateMachine;
        private ILevelsProgressService _levelStatusService;

        [Inject]
        private void Construct(IStateMachine stateMachine, ILevelsProgressService levelStatusService)
        {
            _stateMachine = stateMachine;
            _levelStatusService = levelStatusService;
        }

        private void Start()
        {
            foreach (var button in levelButtons)
            {
                button.SetState(_levelStatusService.GetLevelStatus(button.Level));
                button.Button.OnClickAsObservable()
                    .Subscribe(_ => _stateMachine.Enter<LoadLevelState, int>(button.Level))
                    .AddTo(this);
            }
        }
    }
}