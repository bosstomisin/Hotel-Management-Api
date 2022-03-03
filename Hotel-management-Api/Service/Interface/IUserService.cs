using Hotel_management_Api.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Service.Interface
{
    public interface IUserService
    {
        Task<BaseResponse<UserResponse>> RegisterUser(UserRequest user);
        Task<BaseResponse<LoginResponse>> Login(LoginDto model);
    }
}
