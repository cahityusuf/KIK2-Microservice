using Dapr;
using KIK.Microservice.Product.Application.IntegrationEvents.Events;
using KIK.Microservice.Product.Application.Services.OrderStatusChangedToAwaitingStockValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KIK.Microservice.Product.Api.Controllers
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

        [Topic("pubsub", nameof(OrderStatusChangedToAwaitingStockValidationIntegrationEvent))]
        [HttpPost("/OrderStatusChangedToAwaitingStockValidation")]
        public async Task OrderStatusChangedToAwaitingStockValidation(OrderStatusChangedToAwaitingStockValidationNotification checkout)
        {
            await _mediator.Publish(checkout);
        }
    }
}
