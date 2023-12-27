using KIK.Microservice.Basket.Abstraction.Dtos;

namespace KIK.Microservices.Basket.Application.IntegrationEvents.Events;

public record UserCheckoutAcceptedIntegrationEvent(
    string UserId,
    string UserEmail,
    string City,
    string Street,
    string State,
    string Country,
    string CardNumber,
    string CardHolderName,
    DateTime CardExpiration,
    string CardSecurityNumber,
    Guid RequestId,
    BasketDto Basket);
    //: IntegrationEvent;
