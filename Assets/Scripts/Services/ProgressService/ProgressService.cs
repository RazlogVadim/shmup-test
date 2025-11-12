using Services.ProgressService.Data;
using Services.ProgressService.DataSaver;
using Services.ProgressService.ProgressHandler;
using System.Collections.Generic;

namespace Services.ProgressService
{
    public class ProgressService : IProgressService
    {
        private GameProgress _progress;
        private IDataSaver _dataSaver;

        private List<IProgressReader<GameProgress>> _readers = new();
        private List<IProgressWriter<GameProgress>> _writers = new();

        public ProgressService() => _dataSaver = new PrefsDataSaver();

        public void RegisterHandler(SaveProgressHandler handler)
        {
            _readers.Add(handler);
            _writers.Add(handler);
        }

        public void LoadGameProgress()
        {
            _progress = _dataSaver.LoadProgress() ?? new();
        }

        public void SaveGameProgress()
        {
            UpdateWriters();
            _dataSaver.SaveProgress(_progress);
        }

        public void InformReaders()
        {
            foreach (var reader in _readers)
                reader.Load(_progress);
        }

        public void UpdateWriters()
        {
            foreach (var writer in _writers)
                writer.Save(_progress);
        }
    }
}
