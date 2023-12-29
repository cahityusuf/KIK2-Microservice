using AutoMapper;
using KIK.Microservice.Order.Abstraction.Dtos;

namespace KIK.Microservice.Order.Application.Profiler
{
    public class BasketDtoProfiler : Profile
    {
        public BasketDtoProfiler()
        {
            CreateMap<BasketDto, BasketDto>().ReverseMap();
            CreateMap<BasketItemDto, BasketItemDto>().ReverseMap();
        }
    }
}
