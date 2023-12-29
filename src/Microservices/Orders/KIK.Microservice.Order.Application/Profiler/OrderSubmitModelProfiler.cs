using AutoMapper;
using KIK.Microservice.Order.Abstraction.Models;
using KIK.Microservice.Order.Application.Services.OrderCheckoutAccepted;

namespace KIK.Microservice.Order.Application.Profiler
{
    public class OrderSubmitModelProfiler: Profile
    {
        public OrderSubmitModelProfiler()
        {
            CreateMap<OrderCheckoutAcceptedNotification, OrderSubmitModel>().ReverseMap();
        }
    }
}
