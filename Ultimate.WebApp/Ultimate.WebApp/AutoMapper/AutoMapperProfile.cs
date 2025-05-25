using AutoMapper;
using Ultimate.WebApp.DTO;
using Ultimate.WebApp.Model;

namespace Ultimate.WebApp.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SubscriptionServiceModel, SubscriptionServiceDto>().ReverseMap();
        }
    }
}
