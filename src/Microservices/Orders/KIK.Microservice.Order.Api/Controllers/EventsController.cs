using Dapr;
using KIK.Microservice.Order.Application.IntegrationEvents.Events;
using KIK.Microservice.Order.Application.Services.OrderCheckoutAccepted;
using KIK.Microservice.Order.Application.Services.OrderStatusChangedToSubmitted;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KIK.Microservice.Order.Api.Controllers
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

        [Topic("pubsub", nameof(UserCheckoutAcceptedIntegrationEvent))]
        [HttpPost("/checkout")]
        public async Task Checkout(UserCheckoutAcceptedIntegrationEvent checkout)
        {
            await _mediator.Publish(
                new OrderCheckoutAcceptedNotification(
                    checkout.UserId,
                    checkout.UserEmail,
                    checkout.City,
                    checkout.Street,
                    checkout.State,
                    checkout.Country,
                    checkout.CardNumber,
                    checkout.CardHolderName,
                    checkout.CardExpiration,
                    checkout.CardSecurityNumber,
                    checkout.RequestId,
                    checkout.Basket));
        }

        [Topic("pubsub", nameof(OrderStatusChangedToSubmittedIntegrationEvent))]
        [HttpPost("/orderstatuschangedtosubmitted")]
        public async Task OrderStatusChangedToSubmitted(OrderStatusChangedToSubmittedNotification checkout)
        {
            await _mediator.Publish(checkout);
        }
    }
}
