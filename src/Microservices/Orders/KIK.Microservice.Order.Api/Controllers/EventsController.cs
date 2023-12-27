using Dapr;
using KIK.Microservice.Order.Application.IntegrationEvents.Events;
using Microsoft.AspNetCore.Mvc;

namespace KIK.Microservice.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [Topic("pubsub", nameof(UserCheckoutAcceptedIntegrationEvent))]
        [HttpPost("/checkout")]
        public async Task<ActionResult> Checkout(UserCheckoutAcceptedIntegrationEvent chekout)
        {
            return Ok();
        }
    }
}
