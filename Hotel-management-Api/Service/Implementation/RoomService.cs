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
        public async Task<BaseResponse<RoomResponse>> AddRoom(RoomRequest model)
        {
            if (model == null)
            {
                return new BaseResponse<RoomResponse>() { Data = null, Message = "Model cannot be empty", Success = false, StatusCode = 204 };
            }
            model.RoomTypeName = model.RoomTypeName.ToLower();
            var getByName = await _roomRepo.GetByName(model.RoomTypeName);
            Room room;
            if (getByName != null)
            {
                room = new Room() { RoomNumber = model.RoomNumber };
                var roomType = new RoomType() { RoomTypeId = getByName.RoomTypeId };
                room.RoomTypeId = roomType.RoomTypeId;
            }
            else
            {
                room = _map.Map<Room>(model);
                var roomType = new RoomType() { RoomTypeName = model.RoomTypeName, BasePrice = model.BasePrice };
                room.RoomType = roomType;
            }

            var result = await _roomRepo.InsertRecord(room);
            if (!result)
            {
                return new BaseResponse<RoomResponse>() { Data = null, Message = "Model not added", Success = false, StatusCode = 403 };
            }
            var roomResponse = _map.Map<RoomResponse>(room);
            //roomResponse.BasePrice = room.RoomType.BasePrice;
            //roomResponse.Name = room.RoomType.Name;

            return new BaseResponse<RoomResponse>() { Data = roomResponse, Message = "Room Successfully added", Success = true, StatusCode = 201 };

        }

        public async Task<BaseResponse<RoomResponse>> GetRoom(string id)
        {
            if (id == null)
            {
                return new BaseResponse<RoomResponse>() { Data = null, Message = "Room not found", Success = false, StatusCode = 404 };
            }
            var room = await _roomRepo.GetRoomById(id);
            if (room == null)
            {
                return new BaseResponse<RoomResponse>() { Data = null, Message = "Room not found", Success = false, StatusCode = 404 };
            }
            var roomResponse = _map.Map<RoomResponse>(room);
            return new BaseResponse<RoomResponse>() { Data = roomResponse, Message = "Room succesfully fetched", Success = true, StatusCode = 200 };

        }

        public async Task<BaseResponse<RoomResponse>> DeleteRoom(string id)
        {
            
            if (string.IsNullOrWhiteSpace(id))
            {
                return new BaseResponse<RoomResponse>() { Data = null, Message = "Invalid Id", Success = false, StatusCode = 404 };

            }
            var room = _roomRepo.GetRoomById(id).Result;
            if (room == null)
            {
                return new BaseResponse<RoomResponse>() { Data = null, Message = "Room does not exist", Success = false, StatusCode = 404 };
            }
            var delete = await _roomRepo.DeleteRecord(id);
            if (!delete)
            {
                return new BaseResponse<RoomResponse>() { Data = null, Message = "Room could not be deleted", Success = false, StatusCode = 404 };
            }
            var roomResponse = _map.Map<RoomResponse>(room);
            return new BaseResponse<RoomResponse>() { Data = roomResponse, Message = "Room deleted successfully", Success = true, StatusCode = 200 };

        }

        public async Task<BaseResponse<UpdateRoomResponse>> UpdateRoom(string id, UpdateRoomRequest model)
        {
            if (string.IsNullOrWhiteSpace(id) || model == null)
            {
                return new BaseResponse<UpdateRoomResponse>() { Data = null, Message = "Id and model cannot be empty", Success = false, StatusCode = 204 };
            }
            model.RoomTypeName = model.RoomTypeName.ToLower();
            var getRoomType = _roomRepo.GetByName(model.RoomTypeName).Result;
            if (getRoomType == null)
            {
                return new BaseResponse<UpdateRoomResponse>() { Data = null, Message = "Room type does not exist", Success = false, StatusCode = 404 };

            }
            var getRoom = _roomRepo.GetRoomById(id).Result;
            if (getRoom == null)
            {
                return new BaseResponse<UpdateRoomResponse>() { Data = null, Message = "Room does not exist", Success = false, StatusCode = 404 };
            }
            getRoom = _map.Map(model, getRoom);
            getRoom.RoomTypeId = getRoomType.RoomType.RoomTypeId;
            getRoom.UpdatedDate = DateTime.Now.ToString();
            var updateResult = await _roomRepo.UpdateRecord(getRoom);
            if (!updateResult)
            {
                return new BaseResponse<UpdateRoomResponse>() { Data = null, Message = "Room not updated", Success = false, StatusCode = 404 };
            }
            var roomResponse = _map.Map<UpdateRoomResponse>(getRoom);
            roomResponse.BasePrice = getRoom.RoomType.BasePrice;
            roomResponse.RoomTypeName = getRoom.RoomType.RoomTypeName;
            return new BaseResponse<UpdateRoomResponse>() { Data = roomResponse, Message = "Room properties updated", Success = true, StatusCode = 200 };

        }

        public  BaseResponse<List<RoomResponse>> GetRooms()
        {
            var rooms = _roomRepo.GetAllRooms().ToList();
            if (rooms.Count == 0)
            {
                return new BaseResponse<List<RoomResponse>>() { Data = null, Message = "Rooms does not exist", Success = false, StatusCode = 404 };
            }
            var result = rooms.Select(room => _map.Map<RoomResponse> (room)
            ).ToList();
            return new BaseResponse<List<RoomResponse>>() { Data = result, Message = "Success", Success = true, StatusCode = 200 };

        }
    }
}
