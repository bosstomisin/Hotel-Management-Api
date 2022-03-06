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

        [HttpGet("getRoom/{id}")]
        public async Task<BaseResponse<RoomResponse>> getRoom(string id)
        {
            return await _roomService.GetRoom(id);
        }
    }
}
