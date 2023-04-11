namespace Hangfire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IJobService _jobService;

        public HangfireController(IBackgroundJobClient backgroundJobClient, IJobService jobService, IRecurringJobManager recurringJobManager)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _jobService = jobService;
        }

        /// <summary>
        /// First type of Hangfire job: Fire and Forget
        /// </summary>
        [HttpGet("/FireAndForgetJob")]
        public IActionResult CreateFireAndForgetJob()
        {
            _backgroundJobClient.Enqueue(() => _jobService.FireAndForgetJob());

            return Ok();
        }

        /// <summary>
        /// Second type of Hangfire job: Delayed job which will run every 20 seconds
        /// </summary>
        [HttpGet("/DelayedJob")]
        public IActionResult DelayedJob()
        {
            _backgroundJobClient.Schedule("jobId", () => _jobService.DelayedJob(), TimeSpan.FromSeconds(20));

            return Ok();
        }

        /// <summary>
        /// Third type of Hangfire job: Reccuring job which can repeat in a certain interval we set with Cron
        /// Cron is a software utility for defining the schedule of tasks
        /// </summary>
        [HttpGet("/ReccuringJob")]
        public IActionResult ReccuringJob()
        {
            _recurringJobManager.AddOrUpdate("jobId", () => _jobService.ReccuringJob(), Cron.Minutely);

            return Ok();
        }

    }
}
