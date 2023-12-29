﻿namespace KIK.Microservice.Order.Abstraction.Dtos
{
    public class BasketItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureFileName { get; set; } = string.Empty;
    }
}
