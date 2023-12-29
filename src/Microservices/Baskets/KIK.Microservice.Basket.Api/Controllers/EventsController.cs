using Dapr;
using KIK.Microservices.Basket.Application.IntegrationEvents.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KIK.Microservice.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Topic("pubsub", nameof(OrderStatusChangedToSubmittedIntegrationEvent))]
        [HttpPost("/orderstatuschangedtosubmitted")]
        public async Task OrderStatusChangedToSubmitted(OrderStatusChangedToSubmittedIntegrationEvent checkout)
        {
            //await _mediator.Publish();
        }
    }
}
