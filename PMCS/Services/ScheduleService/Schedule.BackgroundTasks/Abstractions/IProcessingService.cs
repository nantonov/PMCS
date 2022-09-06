namespace Schedule.BackgroundTasks.Abstractions
{
    public interface IProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}
