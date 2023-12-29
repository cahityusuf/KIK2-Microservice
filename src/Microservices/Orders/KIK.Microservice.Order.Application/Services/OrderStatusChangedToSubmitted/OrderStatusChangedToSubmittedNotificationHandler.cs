using Dapr.Actors;
using Dapr.Actors.Client;
using KIK.Microservice.Order.Application.Actors;
using MediatR;

namespace KIK.Microservice.Order.Application.Services.OrderStatusChangedToSubmitted
{
    public class OrderStatusChangedToSubmittedNotificationHandler : INotificationHandler<OrderStatusChangedToSubmittedNotification>
    {
        private readonly IActorProxyFactory _actorProxyFactory;

        public OrderStatusChangedToSubmittedNotificationHandler(IActorProxyFactory actorProxyFactory)
        {
            _actorProxyFactory = actorProxyFactory;
        }

        public async Task Handle(OrderStatusChangedToSubmittedNotification notification, CancellationToken cancellationToken)
        {
            var actorId = new ActorId(notification.OrderId.ToString());

            var orderingProcess = _actorProxyFactory.CreateActorProxy<IOrderingProcessActor>(
            actorId,
                nameof(OrderingProcessActor));

            var orderDetail = await orderingProcess.GetOrderDetail();

            //veri tabanına kaydet

            await orderingProcess.OrderStatusChangedToAwaitingStockValidation();

        }
    }
}
