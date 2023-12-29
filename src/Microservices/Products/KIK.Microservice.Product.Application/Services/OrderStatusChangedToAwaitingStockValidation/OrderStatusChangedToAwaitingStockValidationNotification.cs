﻿using KIK.Microservice.Product.Application.IntegrationEvents.Events;
using MediatR;

namespace KIK.Microservice.Product.Application.Services.OrderStatusChangedToAwaitingStockValidation
{
    public class OrderStatusChangedToAwaitingStockValidationNotification:INotification
    {
        public OrderStatusChangedToAwaitingStockValidationNotification(Guid orderId, IEnumerable<OrderStockItem> orderStockItems)
        {
            OrderId = orderId;
            OrderStockItems = orderStockItems;
        }

        public Guid OrderId { get; set; }
        public IEnumerable<OrderStockItem> OrderStockItems { get; set; }
    }
}
