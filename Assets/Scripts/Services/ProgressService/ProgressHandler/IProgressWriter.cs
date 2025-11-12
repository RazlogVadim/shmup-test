namespace Services.ProgressService.ProgressHandler
{
    public interface IProgressWriter<in TProgress>
    {
        public void Save(TProgress progress);
    }
}
