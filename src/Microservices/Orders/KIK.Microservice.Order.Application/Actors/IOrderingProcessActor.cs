using Dapr.Actors;
using KIK.Microservice.Order.Abstraction.Dtos;

namespace KIK.Microservice.Order.Application.Actors
{
    public interface IOrderingProcessActor : IActor
    {
        Task SubmitAsync(
        string buyerId,
        string buyerEmail,
        string street,
        string city,
        string state,
        string country,
        BasketDto basket);
    }
}
