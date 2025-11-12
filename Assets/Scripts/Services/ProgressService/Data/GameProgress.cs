using Services.LevelProgress;
using System;

namespace Services.ProgressService.Data
{
    [Serializable]
    public class GameProgress
    {
        public LevelData[] LevelsData;
    }
}
