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
        /// <returns></returns>
        [HttpGet("/FireAndForgetJob")]
        public IActionResult CreateFireAndForgetJob()
        {
            _backgroundJobClient.Enqueue(() => _jobService.FireAndForgetJob());

            return Ok();
        }




    }
}
