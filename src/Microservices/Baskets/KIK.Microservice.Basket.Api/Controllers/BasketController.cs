using KIK.Microservice.Basket.Abstraction.Dtos;
using KIK.Microservices.Basket.Application.Services.Commands.Create;
using KIK.Microservices.Basket.Application.Services.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KIK.Microservice.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] BasketDto basket)
        {
            var res = await _mediator.Send(
                new CreateDetailCommand(basket.BuyerId,basket.Items));
            return Ok(res);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckoutDto checkout)
        {
            await _mediator.Publish(new CheckoutNotification(
                                        Guid.NewGuid().ToString(),
                                        checkout.UserId,
                                        checkout.UserEmail,
                                        checkout.City,
                                        checkout.Street,
                                        checkout.State,
                                        checkout.Country,
                                        checkout.CardNumber,
                                        checkout.CardHolderName,
                                        (DateTime)checkout.CardExpiration,
                                        checkout.CardSecurityCode));

            return Accepted("siparişiniz alındı sizi bilgilendireceğim");
        }
    }
}
