using KIK.Microservice.Order.Abstraction.Dtos;

namespace KIK.Microservice.Order.Abstraction.Models
{
    public class OrderSubmitModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime CardExpiration { get; set; }
        public string CardSecurityNumber { get; set; }
        public Guid RequestId { get; set; }
        public BasketDto Basket { get; set; } = new BasketDto();
    }
}
