using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onventis.Test.API.Services;

namespace Onventis.Test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }

        [HttpPost("approve/{id}")]
        public ActionResult Approve(int id)
        {
            _logger.LogInformation($"Invoice with ID {id} is approved");

            new MessageSender().Send();

            return Ok();
        }
    }
}
