using Hotel_management_Api.Data.Dto.Request;
using Hotel_management_Api.Data.Dto.Response;
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
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo )
        {
            _userRepo = userRepo;
        }
        public async Task<BaseResponse<UserResponse>> AddUser(UserRequest user)
        {
            var returnDto = new BaseResponse<UserResponse>();
            if (user == null)
            {
                return new BaseResponse<UserResponse>(){Data = null, Message  = "Model cannot be empty", Success = false, StatusCode = 204};
            }
            var newUser = new User() { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, PhoneNumber = user.PhoneNumber,};
            newUser.Address.Street = user.Street;
            newUser.Address.City = user.City;
            newUser.Address.State = user.State;
            var result = await _userRepo.AddUser(newUser);
            returnDto.Data.City = result.Address.City;
            returnDto.Data.Street = result.Address.Street;
            returnDto.Data.State = result.Address.State;
            returnDto.Data.FirstName = result.FirstName;
            returnDto.Data.LastName = result.LastName;
            returnDto.Data.PhoneNumber = result.PhoneNumber;
            returnDto.Data.Id = result.Id;
            returnDto.Data.Email = result.Email;
        
            return new BaseResponse<UserResponse>() { Data = returnDto.Data, Message = "Model cannot be empty", Success = true, StatusCode = 200 }; 

        }
    }
}
