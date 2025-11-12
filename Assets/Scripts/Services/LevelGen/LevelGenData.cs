using System;
using UnityEngine;

namespace Services.LevelGen
{
    [Serializable]
    public struct LevelGenData
    {
        public Color AsteroidColor;
        public float SpawnInterval;

        public LevelGenData(Color asteroidColor, float spawnInterval)
        {
            AsteroidColor = asteroidColor;
            SpawnInterval = spawnInterval;
        }
    }
}
