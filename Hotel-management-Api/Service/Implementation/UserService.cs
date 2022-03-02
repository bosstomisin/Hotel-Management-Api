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
    public class UserService : IUserService 
    {
        //private readonly IRoomRepo<User> _userRepo;
        private readonly IMapper _map;

        public UserService( IMapper map )
        {
           // _userRepo = userRepo;
            _map = map;
        }
        //public async Task<BaseResponse<UserResponse>> AddUser(UserRequest user)
        //{
        //    if (user == null)
        //    {
        //        return new BaseResponse<UserResponse>(){Data = null, Message  = "Model cannot be empty", Success = false, StatusCode = 204};
        //    }
            
        //    var newUser = _map.Map<User>(user);

        //    var address = new Address() { City = user.City, State = user.State, Street = user.Street };
        //    newUser.Address = address;
            

        //    //var result = await _userRepo.AddUser(newUser);
        //    var userResponse = _map.Map<UserResponse>(result);
        //    userResponse.Street = result.Address.Street;
        //    userResponse.State = result.Address.State;
        //    userResponse.State = result.Address.State;
        
        //    return new BaseResponse<UserResponse>() { Data = userResponse, Message = "User Successfully added", Success = true, StatusCode = 200 }; 

        //}
    }
}
