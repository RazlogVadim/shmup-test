using Services.LevelGen;

namespace Services.LevelGen
{
    public interface ILevelGenService
    {
        LevelGenData GetDataForLevel(int level);
    }
}