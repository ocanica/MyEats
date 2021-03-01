using AutoMapper;
using MyEats.Business.Models.User;
using MyEats.Business.Models.Authentication;
using MyEats.Domain.Entities;
using System.Collections.Generic;
using MyEats.Business.Models.Order;
using MyEats.Business.Models.InOrder;

namespace MyEats.Api.Mapping
{
    public class ModelProfiles : Profile
    {
        public ModelProfiles()
        {
            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.Postcode, opt => opt.MapFrom(src => src.Postcode));

            CreateMap<OrderEntity, OrderModel>();

            CreateMap<InOrderEntity, InOrderModel>();

            CreateMap<AuthenticationResponse, AuthenticationModel>();
        }

    }
}
