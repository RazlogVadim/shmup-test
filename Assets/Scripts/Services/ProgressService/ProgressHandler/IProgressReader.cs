namespace Services.ProgressService.ProgressHandler
{
    public interface IProgressReader<in TProgress>
    {
        public void Load(TProgress progress);
    }
}
