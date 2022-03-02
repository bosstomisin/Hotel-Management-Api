using AutoMapper;
using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Data.Models;
using Hotel_management_Api.Data.Repository.Interface;
using Hotel_management_Api.Models;
using Hotel_management_Api.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Service.Implementation
{
    public class UserService : IUserService 
    {
        private readonly IMapper _map;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService( IMapper map, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _map = map;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<BaseResponse<UserResponse>> RegisterUser(UserRequest user)
        {
            if (user == null)
            {
                return new BaseResponse<UserResponse>() { Data = null, Message = "Model cannot be empty", Success = false, StatusCode = 204 };
            }
            var getUser = _userManager.Users.FirstOrDefault(x => x.Email == user.Email);
            if (getUser != null)
            {
                return new BaseResponse<UserResponse>() { Data = null, Message = "Email already exist", Success = false, StatusCode = 400 };
            }

            var newUser = _map.Map<User>(user);
            newUser.UserName = user.Email;

            var address = new Address() { City = user.City, State = user.State, Street = user.Street };
            newUser.Address = address;

            var createUser = await _userManager.CreateAsync(newUser, user.Password);
            string errors = "";
            if (!createUser.Succeeded)
            {
                foreach (var error in createUser.Errors)
                {
                    errors += error.ToString() + "/n";
                }
                return new BaseResponse<UserResponse>() { Data = null, Message = errors, Success = false, StatusCode = 401 };
            }

            if (await _roleManager.FindByNameAsync("Regular") == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("Regular"));
            }
            var addRole = await _userManager.AddToRoleAsync(newUser, "Regular");
            if (!addRole.Succeeded)
            {
                return new BaseResponse<UserResponse>() { Data = null, Message = "User role added", Success = false, StatusCode = 401 };

            }
            var userResponse = _map.Map<UserResponse>(newUser);
            userResponse.City = newUser.Address.City;
            userResponse.Street = newUser.Address.Street;
            userResponse.State = newUser.Address.State;


            return new BaseResponse<UserResponse>() { Data = userResponse, Message = "User Successfully created", Success = true, StatusCode = 200 };

        }
    }
}
