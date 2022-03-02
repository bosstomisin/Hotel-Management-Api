using AutoMapper;
using Hotel_management_Api.Data.Dto.Response;
using Hotel_management_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserResponse, User>().ReverseMap();
        }
    }
}
