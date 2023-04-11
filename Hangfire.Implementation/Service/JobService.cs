namespace Hangfire.Implementation.Service;

public class JobService : IJobService
{
    public void FireAndForgetJob()
    {
        Console.WriteLine("First type of job: Hello from Fire and Forget type of job");
    }

    public void DelayedJob()
    {
        Console.WriteLine("Second type of job: Hello from Delayed type of job");
    }

    public void ReccuringJob()
    {
        Console.WriteLine("Third type of job: Hello from Scheduled type of job");
    }

    public void ContinuationJob()
    {
        Console.WriteLine("Fourth type of job: Hello from Continuation type of job");
    }
}