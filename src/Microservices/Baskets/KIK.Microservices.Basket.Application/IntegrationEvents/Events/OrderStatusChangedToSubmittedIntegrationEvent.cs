namespace KIK.Microservices.Basket.Application.IntegrationEvents.Events;

public record OrderStatusChangedToSubmittedIntegrationEvent(
    Guid OrderId,
    string OrderStatus,
    string BuyerId,
    string BuyerEmail);
    //: IntegrationEvent;
