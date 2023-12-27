using KIK.Microservice.Basket.Abstraction.Dtos;
using MediatR;

namespace KIK.Microservices.Basket.Application.Services.Commands.Create
{
    public class CreateDetailCommand: IRequest<BasketDto>
    {
        public CreateDetailCommand(Guid buyerId, List<BasketItemDto> items)
        {
            BuyerId = buyerId;
            Items = items;
        }

        public Guid Id => Guid.NewGuid();

        public Guid BuyerId { get; set; } = Guid.NewGuid();
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}
