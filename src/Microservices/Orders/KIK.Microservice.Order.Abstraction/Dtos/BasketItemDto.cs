namespace KIK.Microservice.Order.Abstraction.Dtos
{
    public record BasketItemDto(Guid ProductId, string ProductName, decimal UnitPrice, int Quantity);
}
