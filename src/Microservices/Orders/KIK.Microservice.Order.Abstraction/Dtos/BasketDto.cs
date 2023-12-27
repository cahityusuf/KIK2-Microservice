namespace KIK.Microservice.Order.Abstraction.Dtos
{
    public class BasketDto
    {
        public Guid BuyerId { get; set; } = Guid.NewGuid();
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}
