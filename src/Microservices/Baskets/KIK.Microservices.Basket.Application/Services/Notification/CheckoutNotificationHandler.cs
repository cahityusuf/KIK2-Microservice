using Dapr.Client;
using KIK.Microservice.Basket.Abstraction.Dtos;
using KIK.Microservices.Basket.Application.IntegrationEvents.Events;
using MediatR;

namespace KIK.Microservices.Basket.Application.Services.Notification
{
    public class CheckoutNotificationHandler : INotificationHandler<CheckoutNotification>
    {
        public async Task Handle(CheckoutNotification notification, CancellationToken cancellationToken)
        {
            const string storeName = "statestore";

            var daprClient = new DaprClientBuilder().Build();

            var basket = await daprClient.GetStateAsync<BasketDto>(storeName, notification.BuyerId.ToString());

            var checkoutData = new UserCheckoutAcceptedIntegrationEvent(
                notification.BuyerId,
                notification.UserEmail,
                notification.City,
                notification.Street,
                notification.State,
                notification.Country,
                notification.CardNumber,
                notification.CardHolderName,
                notification.CardExpiration,
                notification.CardSecurityCode,
                Guid.Parse(notification.RequestId),
                basket);


            var topicName = checkoutData.GetType().Name;

            await daprClient.PublishEventAsync<UserCheckoutAcceptedIntegrationEvent>(
                "pubsub",
                topicName, 
                checkoutData);


        }
    }
}
