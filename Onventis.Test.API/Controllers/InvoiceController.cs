using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpPost]
        public ActionResult Approve(int id)
        {
            _logger.LogInformation($"Invoice with ID {id} is approved");
            return Ok();
        }
    }
}
