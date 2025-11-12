using Services.ProgressService.Data;
using Zenject;

namespace Services.ProgressService.ProgressHandler
{
    public abstract class SaveProgressHandler : IProgressReader<GameProgress>, IProgressWriter<GameProgress>
    {
        [Inject]
        private void Construct(IProgressService progressService) => progressService.RegisterHandler(this);

        public abstract void Load(GameProgress progress);
        public abstract void Save(GameProgress progress);
    }
}
