using Infrastructure.StateMachine.States;

namespace Infrastructure.StateMachine.Factory
{
    public interface IStateFactory
    {
        TState Create<TState>() where TState : IExitableState;
    }
}