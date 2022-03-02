using Hotel_management_Api.Data.Dto.Request;
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
        public async Task<bool> AddUser(UserRequest user)
        {
            if (user == null)
            {
                return false;
            }
            var newUser = new User() { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, PhoneNumber = user.PhoneNumber,};
            newUser.Address.Street = user.Street;
            newUser.Address.City = user.City;
            newUser.Address.State = user.State;
            return await _userRepo.AddUser(newUser);
            
        }
    }
}
