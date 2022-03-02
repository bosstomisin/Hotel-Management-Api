﻿using Hotel_management_Api.Data.Dto.Request;
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
        public async Task<bool> AddUser(UserRequest user)
        {
            return await _userService.AddUser(user);
        }
    }
}
