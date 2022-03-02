using Hotel_management_Api.Data.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Service.Interface
{
    public interface IUserService
    {
        Task<bool> AddUser(UserRequest user);
    }
}
