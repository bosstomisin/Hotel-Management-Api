using AutoMapper;
using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Data.Models;
using Hotel_management_Api.Data.Repository.Interface;
using Hotel_management_Api.Models;
using Hotel_management_Api.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _map;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IOptions<JWTConfig> _jwt;

        public UserService(IMapper map, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager, IOptions<JWTConfig> options)
        {
            _map = map;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwt = options;
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

            var newUser = _map.Map<AppUser>(user);
            newUser.UserName = user.Email;

            var address = new Address() { City = user.City, State = user.State, Street = user.Street };
            newUser.Address = address;

            var createUser = await _userManager.CreateAsync(newUser, user.Password);
            string errors = "";
            if (!createUser.Succeeded)
            {
                foreach (var error in createUser.Errors)
                {
                    errors += error.ToString() + "\n";
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

        public async Task<BaseResponse<LoginResponse>> Login(LoginDto model)
        {
            if (model == null)
            {
                return new BaseResponse<LoginResponse>() { Data = null, Message = "Model cannot be empty", Success = false, StatusCode = 204 };
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new BaseResponse<LoginResponse>() { Data = null, Message = "Email not found", Success = false, StatusCode = 404 };
            }
            var signIn = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!signIn.Succeeded)
            {
                return new BaseResponse<LoginResponse>() { Data = null, Message = "Credentials not correct", Success = false, StatusCode = 404 };
            }
            var userRole = await _userManager.GetRolesAsync(user) as List<string>;
            var token = JWTService.GenerateToken(user, userRole, _jwt);
            var loginRespone = new LoginResponse() { Email = user.Email, Token = token, UserId = user.Id };
            return new BaseResponse<LoginResponse>() { Data = loginRespone, Message = "Login Successful", Success = true, StatusCode = 200 };

        }

        //public async Task<BaseResponse<UserResponse>> GetUserById(string id){
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return new BaseResponse<UserResponse>() { Data = null, Message = "User not found", Success = false, StatusCode = 404 };
        //    }
        //    var user = await _userManager.GetUserAsync();
        //}

    }
}
