namespace Hangfire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IJobService _jobService;

        public HangfireController(IBackgroundJobClient backgroundJobClient, IJobService jobService)
        {
            _backgroundJobClient = backgroundJobClient;
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




    }
}
