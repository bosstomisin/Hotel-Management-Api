using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        //[Authorize]
        [HttpPost("add-room")]
        public async Task<BaseResponse<RoomResponse>> AddRoom(RoomRequest model)
        {
            return await _roomService.AddRoom(model);
        }

        [HttpGet("get-room/{id}")]
        public async  Task<BaseResponse<RoomResponse>> GetRoom(string id)
        {
            return await  _roomService.GetRoom(id);
        }

        //[HttpDelete("delete-room/{id}")]
        //public async Task<BaseResponse<bool>> DeleteRoom(string id)
        //{
        //    return await _roomService.DeleteRoom(id);
        //}

        //[HttpPut("update-room/{id}")]
        //public async Task<BaseResponse<RoomResponse>> UpdateRoom(string id, RoomRequest room)
        //{
        //    return await _roomService.UpdateRoom(id, room);
        //}

 
        [HttpGet("get-rooms")]
        public  BaseResponse<List<RoomResponse>> GetRooms()
        {
            return _roomService.GetRooms();
        }
    }
}
