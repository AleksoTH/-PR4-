

using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/test")]
    public class SimpleTestController : ControllerBase
    {

        private readonly ILogger<SimpleTestController> _logger;

        public SimpleTestController(ILogger<SimpleTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IEnumerable<String> Get()
        {
            return Enumerable.Range(1, 5).Select(index => "test")
            .ToArray();
        }
    }
}