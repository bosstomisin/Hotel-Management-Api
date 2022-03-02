﻿using AutoMapper;
using Hotel_management_Api.Data.Dto;
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



            var result = await _roomRepo.AddRoom(newRoom);
            var roomResponse = _map.Map<RoomResponse>(result);
         

            return new BaseResponse<RoomResponse>() { Data = roomResponse, Message = "User Successfully added", Success = true, StatusCode = 200 };

        }
    }
}
