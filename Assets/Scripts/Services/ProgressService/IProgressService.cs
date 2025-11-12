using Services.ProgressService.ProgressHandler;

namespace Services.ProgressService
{
    public interface IProgressService
    {
        void InformReaders();
        void LoadGameProgress();
        public void RegisterHandler(SaveProgressHandler handler);
        void SaveGameProgress();
    }
}
