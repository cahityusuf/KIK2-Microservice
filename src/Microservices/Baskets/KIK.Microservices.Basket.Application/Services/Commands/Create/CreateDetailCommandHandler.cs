using Dapr.Client;
using KIK.Microservice.Basket.Abstraction.Dtos;
using MediatR;

namespace KIK.Microservices.Basket.Application.Services.Commands.Create
{
    public class CreateDetailCommandHandler : IRequestHandler<CreateDetailCommand, BasketDto>
    {
        public async Task<BasketDto> Handle(CreateDetailCommand request, CancellationToken cancellationToken)
        {
            const string storeName = "statestore";

            var daprClient = new DaprClientBuilder().Build();
            await daprClient.SaveStateAsync(storeName, request.BuyerId.ToString(), request);

            var res = await daprClient.GetStateAsync<BasketDto>(storeName, request.BuyerId.ToString());
            return res;
        }
    }
}
