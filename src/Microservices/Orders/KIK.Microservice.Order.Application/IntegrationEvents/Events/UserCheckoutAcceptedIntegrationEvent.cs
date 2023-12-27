using KIK.Microservice.Order.Abstraction.Dtos;

namespace KIK.Microservice.Order.Application.IntegrationEvents.Events;

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
