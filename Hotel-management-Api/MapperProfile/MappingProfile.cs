using AutoMapper;
using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Data.Models;
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
            CreateMap<Room, RoomResponse>().ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.RoomType.BasePrice))
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.RoomTypeName));
            CreateMap<RoomRequest, Room>().ReverseMap();
            CreateMap<UpdateRoomRequest, Room>().ReverseMap();
            CreateMap<Room, UpdateRoomResponse>().ReverseMap();
            CreateMap<BookingRequest, Booking>();
            CreateMap<Booking, BookingResponse>();
            CreateMap<Booking, UpdateBookingResponse>();

        }
    }
}
