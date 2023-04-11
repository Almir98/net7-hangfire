namespace Hangfire.Contracts.Interaface;

public interface IJobService
{
    void FireAndForgetJob();
    void DelayedJob();
    void ReccuringJob();
    void ContinuationJob();
}