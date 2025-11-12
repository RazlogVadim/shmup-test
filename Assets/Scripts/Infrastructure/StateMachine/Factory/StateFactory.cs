using Infrastructure.StateMachine.States;
using Zenject;

namespace Infrastructure.StateMachine.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _diContainer;

        public StateFactory(DiContainer diContainer) => _diContainer = diContainer;

        public TState Create<TState>() where TState : IExitableState =>
            _diContainer.Instantiate<TState>();
    }
}
