namespace Infrastructure.StateMachine.States
{
    public interface IPayloadedState<T> : IExitableState
    {
        void Enter(T payload);
    }
}
