using Services.LevelGen;
using System;

namespace Services.LevelProgress
{
    [Serializable]
    public class LevelData
    {
        public LevelStatus LevelStatus;
        public LevelGenData LevelGenData;

        public LevelData(LevelStatus levelStatus, LevelGenData levelGenData)
        {
            LevelStatus = levelStatus;
            LevelGenData = levelGenData;
        }
    }
}
