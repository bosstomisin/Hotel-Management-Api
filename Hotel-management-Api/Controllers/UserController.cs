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

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("add-user")]
        public async Task<BaseResponse<UserResponse>> RegisterUser(UserRequest user)
        {
            return await _userService.RegisterUser(user);

        }

        [HttpPost("login")]
        public async Task<BaseResponse<LoginResponse>> LoginUser(LoginDto model)
        {
            return await _userService.Login(model);
        }
    }
}
