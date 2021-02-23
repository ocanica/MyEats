using AutoMapper;
using MyEats.Business.Models;
using MyEats.Domain.Entities;
using System.Collections.Generic;

namespace MyEats.Api.Mapping
{
    public class ModelProfiles : Profile
    {
        public ModelProfiles()
        {
            CreateMap<UserEntity, UserModel>();
            CreateMap<AuthenticationResponse, AuthenticationModel>();
        }
    }
}
