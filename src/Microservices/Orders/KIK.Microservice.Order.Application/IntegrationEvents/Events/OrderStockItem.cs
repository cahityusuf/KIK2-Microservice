namespace KIK.Microservice.Order.Application.IntegrationEvents.Events
{
    public record OrderStockItem(Guid ProductId, int Units);
}
