using Gameplay;
using UnityEngine;

namespace Services.LevelGen
{
    public class LevelGenService : ILevelGenService
    {
        public LevelGenData GetDataForLevel(int level) => 
            new(Random.ColorHSV(), 1f - level * .1f);
    }
}
