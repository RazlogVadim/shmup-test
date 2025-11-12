using Services.ProgressService.Data;
using UnityEngine;

namespace Services.ProgressService.DataSaver
{
    public class PrefsDataSaver : IDataSaver
    {
        public void SaveProgress(GameProgress progress)
        {
            PlayerPrefs.SetString("Progress", JsonUtility.ToJson(progress));
        }

        public GameProgress LoadProgress()
        {
            return PlayerPrefs.HasKey("Progress")
                ? JsonUtility.FromJson<GameProgress>(PlayerPrefs.GetString("Progress"))
                : null;
        }
    }
}
