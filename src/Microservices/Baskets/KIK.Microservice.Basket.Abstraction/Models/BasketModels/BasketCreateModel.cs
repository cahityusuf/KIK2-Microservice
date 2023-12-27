namespace KIK.Microservice.Basket.Abstraction.Models.BasketModels
{
    public class BasketCreateModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
