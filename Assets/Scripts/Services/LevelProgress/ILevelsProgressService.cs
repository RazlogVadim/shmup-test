using R3;
using Services.LevelGen;

namespace Services.LevelProgress
{
    public interface ILevelsProgressService
    {
        int CurrentLevel { get; set; }
        Subject<int> OnLevelComplete { get; }

        void CompleteLevel(int level);
        LevelGenData GetGenData(int level);
        LevelStatus GetLevelStatus(int level);
    }
}