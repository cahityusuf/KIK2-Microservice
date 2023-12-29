namespace KIK.Microservice.Product.Application.IntegrationEvents.Events;

public record OrderStatusChangedToAwaitingStockValidationIntegrationEvent(
    Guid OrderId,
    string OrderStatus,
    string Description,
    IEnumerable<OrderStockItem> OrderStockItems,
    string BuyerId);
