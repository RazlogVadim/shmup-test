using R3;

namespace Gameplay.Player
{
    public interface IPlayerService
    {
        ReactiveProperty<int> PlayerHitPoints { get; }

        void Initialize();
    }
}