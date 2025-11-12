using Services.ProgressService.Data;

namespace Services.ProgressService.DataSaver
{
    public interface IDataSaver
    {
        GameProgress LoadProgress();
        void SaveProgress(GameProgress progress);
    }
}