using R3;

namespace Gameplay.Game.WinConditions
{
    public interface IGameWinCondition
    {
        Subject<Unit> OnGameWon { get; }
    }
}