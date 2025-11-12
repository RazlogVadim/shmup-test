using Configs;
using R3;
using Services.LevelGen;
using Services.ProgressService.Data;
using Services.ProgressService.ProgressHandler;
using System.Collections.Generic;
using System.Linq;

namespace Services.LevelProgress
{
    public class LevelsProgressService : SaveProgressHandler, ILevelsProgressService
    {
        private List<LevelData> _levelsData;

        public int CurrentLevel { get; set; }
        public Subject<int> OnLevelComplete { get; } = new();

        private readonly ILevelGenService _levelGenService;
        private readonly LevelsConfig _levelsConfig;

        public LevelsProgressService(ILevelGenService levelGenService, LevelsConfig levelsConfig)
        {
            _levelGenService = levelGenService;
            _levelsConfig = levelsConfig;

            _levelsData = GetDefaults();
        }

        public override void Load(GameProgress progress) =>
            _levelsData = progress.LevelsData?.ToList() ?? GetDefaults();

        public override void Save(GameProgress progress) =>
            progress.LevelsData = _levelsData.ToArray();

        public void CompleteLevel(int level)
        {
            _levelsData[level - 1].LevelStatus = LevelStatus.Completed;

            if (level == _levelsData.Count && level < _levelsConfig.LevelsAmount)
                _levelsData.Add(CreateLevelData(level));

            OnLevelComplete.OnNext(level);
        }

        public LevelStatus GetLevelStatus(int level) =>
            GetData(level)?.LevelStatus ?? LevelStatus.Locked;

        public LevelGenData GetGenData(int level) =>
            GetData(level)?.LevelGenData ?? default;

        public LevelData GetData(int level) =>
            level <= _levelsData.Count ? _levelsData[level - 1] : null;

        public List<LevelData> GetDefaults() => new() { CreateLevelData(1) };

        public LevelData CreateLevelData(int level) =>
            new(LevelStatus.Unlocked, _levelGenService.GetDataForLevel(level));
    }
}
