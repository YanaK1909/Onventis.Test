using EventBus.Base.Standard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onventis.Test.Shared.Events;

namespace Onventis.Test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IEventBus _eventBus;

        public InvoiceController(ILogger<InvoiceController> logger, IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        [HttpPost("approve/{id}")]
        public ActionResult Approve(int id)
        {
            _logger.LogInformation($"Invoice with ID {id} is approved");

            var approvedEvent = new InvoiceApprovedEvent { InvoiceId = id };
            _eventBus.Publish(approvedEvent);

            return Ok();
        }
    }
}
