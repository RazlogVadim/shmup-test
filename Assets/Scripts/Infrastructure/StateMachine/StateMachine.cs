using Infrastructure.StateMachine.States;
using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _registeredStates = new();
        private IExitableState _currentState;

        public void Register<TState>(TState state) where TState : IExitableState
        {
            var type = typeof(TState);
            _registeredStates.Add(type, state);
        }

        public void Enter<TState>() where TState : IState =>
            ChangeState<TState>().Enter();

        public void Enter<TState, TPayload>(TPayload payload) where TState : IPayloadedState<TPayload> =>
            ChangeState<TState>().Enter(payload);

        private TState ChangeState<TState>() where TState : IExitableState
        {
            _currentState?.Exit();
            TState nextState = GetState<TState>();
            _currentState = nextState;
            return nextState;
        }

        private TState GetState<TState>() where TState : IExitableState =>
            (TState)_registeredStates[typeof(TState)];
    }
}
