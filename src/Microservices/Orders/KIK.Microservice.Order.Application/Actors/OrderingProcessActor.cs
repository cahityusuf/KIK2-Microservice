using Dapr.Actors.Runtime;
using Dapr.Client;
using KIK.Microservice.Order.Abstraction.Dtos;
using KIK.Microservice.Order.Application.IntegrationEvents.Events;

namespace KIK.Microservice.Order.Application.Actors
{
    public class OrderingProcessActor : Actor, IOrderingProcessActor
    {
        private const string OrderDetailsStateName = "OrderDetails";
        private const string OrderStatusStateName = "OrderStatus";

        public OrderingProcessActor(ActorHost host) : base(host)
        {
        }

        private Guid OrderId => Guid.Parse(Id.GetId());

        public async Task<OrderState> GetOrderDetail()
        {
            return await StateManager.GetStateAsync<OrderState>(OrderDetailsStateName);
        }

        public async Task OrderStatusChangedToAwaitingStockValidation()
        {
            const string storeName = "statestore";

            var daprClient = new DaprClientBuilder().Build();

            var order = await StateManager.GetStateAsync<OrderState>(OrderDetailsStateName);

            await daprClient.PublishEventAsync<OrderStatusChangedToAwaitingStockValidationIntegrationEvent>(
                "pubsub",
                nameof(OrderStatusChangedToAwaitingStockValidationIntegrationEvent),
                    new OrderStatusChangedToAwaitingStockValidationIntegrationEvent(
                        OrderId,
                        OrderStatus.AwaitingStockValidation.Name,
                        "Grace period elapsed; waiting for stock validation.",
                        order.OrderItems
                            .Select(orderItem => new OrderStockItem(orderItem.ProductId, orderItem.Units)),
                        order.BuyerId));
        }

        public async Task SubmitAsync(string buyerId,
        string buyerEmail,
        string street,
        string city,
        string state,
        string country,
        BasketDto basket)
        {
            var orderState = new OrderState
            {
                OrderDate = DateTime.UtcNow,
                OrderStatus = OrderStatus.Submitted,
                Description = "Submitted",
                Address = new OrderAddressState
                {
                    Street = street,
                    City = city,
                    State = state,
                    Country = country
                },
                BuyerId = buyerId,
                BuyerEmail = buyerEmail,
                OrderItems = basket.Items
                    .Select(item => new OrderItemState
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        UnitPrice = item.UnitPrice,
                        Units = item.Quantity,
                        //PictureFileName = item.PictureFileName
                    })
                    .ToList()
            };

            await StateManager.SetStateAsync(OrderDetailsStateName, orderState);
            await StateManager.SetStateAsync(OrderStatusStateName, OrderStatus.Submitted);

            //var order = await StateManager.GetStateAsync<OrderState>(OrderDetailsStateName);

            const string storeName = "statestore";

            var daprClient = new DaprClientBuilder().Build();

            await daprClient.PublishEventAsync<OrderStatusChangedToSubmittedIntegrationEvent>(
                "pubsub",
                nameof(OrderStatusChangedToSubmittedIntegrationEvent),
                new OrderStatusChangedToSubmittedIntegrationEvent(
                OrderId,
                OrderStatus.Submitted.Name,
                buyerId,
                buyerEmail));

        }
    }
}
