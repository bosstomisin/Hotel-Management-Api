using AutoMapper;
using Hotel_management_Api.Data.Dto;
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
            CreateMap<AppUser, UserResponse>().ReverseMap();
            CreateMap<UserRequest, AppUser>().ReverseMap();
            CreateMap<Room, RoomResponse>().ReverseMap();
            CreateMap<RoomRequest, Room>().ReverseMap();
        }
    }
}
