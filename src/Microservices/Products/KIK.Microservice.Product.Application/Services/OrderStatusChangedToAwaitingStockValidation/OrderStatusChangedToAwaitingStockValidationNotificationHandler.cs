using MediatR;

namespace KIK.Microservice.Product.Application.Services.OrderStatusChangedToAwaitingStockValidation
{
    public class OrderStatusChangedToAwaitingStockValidationNotificationHandler : INotificationHandler<OrderStatusChangedToAwaitingStockValidationNotification>
    {
        public async Task Handle(OrderStatusChangedToAwaitingStockValidationNotification notification, CancellationToken cancellationToken)
        {
            foreach (var item in notification.OrderStockItems)
            {
                //item.ProductId ile veri tabanında stpk kontrolü yapılır
                //item.Units değeri stoktan küçük yada eşit ise stok var demektir

            }

            if (true) //stok var ise çalışsın
            {

            }
            else // stok yok ise çalışsın
            {

            }

        }
    }
}
