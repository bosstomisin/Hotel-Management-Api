using Hotel_management_Api.Data.Repository.Interface;
using Hotel_management_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Repository.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _ctx;
        public UserRepo(DataContext ctx)
        {
            _ctx = ctx;
        } 

        public async Task<bool> AddUser(User user)
        {
           _ctx.Add(user);
            var addUser = await _ctx.SaveChangesAsync();
            if (addUser < 1)
            {
                return false;
            }
            return true;
        }
    }
}
