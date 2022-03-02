using Hotel_management_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Repository.Interface
{
    public interface IUserRepo
    {
        Task<User> AddUser(User user);
    }
}
