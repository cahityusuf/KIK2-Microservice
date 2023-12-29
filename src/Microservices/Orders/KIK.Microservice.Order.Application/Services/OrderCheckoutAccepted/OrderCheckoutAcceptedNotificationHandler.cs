using AutoMapper;
using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Client;
using KIK.Microservice.Order.Abstraction.Dtos;
using KIK.Microservice.Order.Abstraction.Models;
using KIK.Microservice.Order.Application.Actors;
using MediatR;
using Microsoft.Extensions.Logging;
using static Google.Rpc.Context.AttributeContext.Types;

namespace KIK.Microservice.Order.Application.Services.OrderCheckoutAccepted
{
    public class OrderCheckoutAcceptedNotificationHandler : INotificationHandler<OrderCheckoutAcceptedNotification>
    {
        private readonly IActorProxyFactory _actorProxyFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderCheckoutAcceptedNotificationHandler> _logger;

        public OrderCheckoutAcceptedNotificationHandler(IMapper mapper, IActorProxyFactory actorProxyFactory = null, ILogger<OrderCheckoutAcceptedNotificationHandler> logger = null)
        {
            _mapper = mapper;
            _actorProxyFactory = actorProxyFactory;
            _logger = logger;
        }
        public async Task Handle(OrderCheckoutAcceptedNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                if (notification.RequestId != Guid.Empty)
                {
                    //const string storeName = "statestore";

                    //var daprClient = new DaprClientBuilder().Build();
                    //await daprClient.SaveStateAsync(storeName, request.BuyerId.ToString(), request);

                    var actorId = new ActorId(notification.RequestId.ToString());

                    var orderingProcess = _actorProxyFactory.CreateActorProxy<IOrderingProcessActor>(
                    actorId,
                        nameof(OrderingProcessActor));

                    await orderingProcess.SubmitAsync(
                                    notification.UserId, notification.UserEmail, notification.Street, notification.City,
                                    notification.State, notification.Country, notification.Basket);
                }
                else
                {
                    _logger.LogWarning("Invalid IntegrationEvent - RequestId is missing - {@IntegrationEvent}", notification);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
