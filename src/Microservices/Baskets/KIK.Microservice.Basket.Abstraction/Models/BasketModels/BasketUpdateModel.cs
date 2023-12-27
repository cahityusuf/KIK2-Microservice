namespace KIK.Microservice.Basket.Abstraction.Models.BasketModels
{

    public class BasketUpdateModel : BasketCreateModel
    {
        public Guid BuyerId { get; set; }
    }
}
