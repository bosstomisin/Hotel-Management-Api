using AutoMapper;
using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Data.Models;
using Hotel_management_Api.Data.Repository.Interface;
using Hotel_management_Api.Models;
using Hotel_management_Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Service.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _map;

        public RoomService(IRoomRepo roomRepo, IMapper map)
        {
            _roomRepo = roomRepo;
            _map = map;
        }
        public async Task<BaseResponse<RoomResponse>> AddRoom(RoomRequest room)
        {
            if (room == null)
            {
                return new BaseResponse<RoomResponse>() { Data = null, Message = "Model cannot be empty", Success = false, StatusCode = 204 };
            }

            var newRoom = _map.Map<Room>(room);
            newRoom.RoomType = room.RoomType;
           //newRoom.RoomType = Enum.GetName(typeof(RoomTypes), room.RoomType);



            var result = await _roomRepo.InsertRecord(newRoom);
            var roomResponse = _map.Map<RoomResponse>(result);
         

            return new BaseResponse<RoomResponse>() { Data = roomResponse, Message = "Room Successfully added", Success = true, StatusCode = 201 };

        }

        public async Task<BaseResponse<RoomResponse>> GetRoom(string id)
        {
            var room = await _roomRepo.GetRecord(id);
            if (room == null)
            {
                return new BaseResponse<RoomResponse>() { Data = null, Message = "Room not found", Success = false, StatusCode = 404 };

            }
            var roomResponse = _map.Map<RoomResponse>(room);
            roomResponse.RoomType = Enum.GetName(typeof(RoomTypes), room.RoomType);
            return new BaseResponse<RoomResponse>() { Data = roomResponse, Message = "Room succesfully fetched", Success = true, StatusCode = 201 };

        }

    }
}
