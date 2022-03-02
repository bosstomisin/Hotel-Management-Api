using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Service.Interface;
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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("add-room")]
        public async Task<BaseResponse<RoomResponse>> AddRoom(RoomRequest model)
        {
            return await _roomService.AddRoom(model);
        }
    }
}
