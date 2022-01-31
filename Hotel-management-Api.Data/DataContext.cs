using Microsoft.EntityFrameworkCore;
using System;

namespace Hotel_management_Api.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext()
        {

        }
    }
}
