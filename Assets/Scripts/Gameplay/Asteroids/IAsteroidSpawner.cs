using R3;

namespace Gameplay.Asteroids
{
    public interface IAsteroidSpawner
    {
        ReactiveProperty<int> AsteroidsDestroyed { get; }

        void Initialize();
    }
}