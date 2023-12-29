using MediatR;

namespace KIK.Microservice.Order.Application.Services.OrderStatusChangedToSubmitted
{
    public class OrderStatusChangedToSubmittedNotification:INotification
    {
        public OrderStatusChangedToSubmittedNotification(
            Guid orderId,
            string orderStatus,
            string buyerId,
            string buyerEmail
            )
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
            BuyerId = buyerId;
            BuyerEmail = buyerEmail;
        }

        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string BuyerId { get; set; }
        public string BuyerEmail { get; set; }
    }
}
