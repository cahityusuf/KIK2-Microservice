using MediatR;

namespace KIK.Microservices.Basket.Application.Services.Notification
{
    public class CheckoutNotification : INotification
    {
        public CheckoutNotification(
           string requestId,
           string buyerId,
           string userEmail,
           string city,
           string street,
           string state,
           string country,
           string cartNumber,
           string cartHolderName,
           DateTime cardExpiration,
           string cardSecurityCode)
        {
            BuyerId = buyerId;
            UserEmail = userEmail;
            City = city;
            Street = street;
            State = state;
            Country = country;
            CardNumber = cartNumber;
            CardHolderName = cartHolderName;
            CardExpiration = cardExpiration;
            CardSecurityCode = cardSecurityCode;
            RequestId = requestId;
        }
        public string RequestId { get; set; }
        public string BuyerId { get; set; }
        public string UserEmail { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime CardExpiration { get; set; }
        public string CardSecurityCode { get; set; }
    }
}
