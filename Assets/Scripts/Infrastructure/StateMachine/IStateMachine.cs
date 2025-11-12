using Infrastructure.StateMachine.States;

namespace Infrastructure.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : IPayloadedState<TPayload>;
        void Register<TState>(TState state) where TState : IExitableState;
    }
}