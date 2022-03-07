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
          
            var result = await _roomRepo.InsertRecord(newRoom);
            var roomResponse = _map.Map<Room, RoomResponse>(result);
         

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
            return new BaseResponse<RoomResponse>() { Data = roomResponse, Message = "Room succesfully fetched", Success = true, StatusCode = 200 };

        }

        public async Task<BaseResponse<bool>> DeleteRoom(string id)
        {
            var room = _roomRepo.GetRecord(id).Result;
            if (room == null) 
            {
                return new BaseResponse<bool>() { Data = false, Message = "Room does not exist", Success = false, StatusCode = 404 };
            }
            var delete = await _roomRepo.DeleteRecord(id);
            if (!delete)
            {
                return new BaseResponse<bool>() { Data = false, Message = "Room could not be deleted", Success = false, StatusCode = 404 };
            }
            return new BaseResponse<bool>() { Data = true, Message = "Room deleted successfully", Success = true, StatusCode = 200 };

        }

    }
}
