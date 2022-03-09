using Hotel_management_Api.Data.Repository.Interface;
using Hotel_management_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Repository.Implementation
{
    public class RoomRepo : GenericRepo<Room>, IRoomRepo
    {
        public RoomRepo(DataContext context) : base(context)
        {
        }
        public async Task<Room> GetByName(string name)
        {
            return await _ctx.Room.Include(s => s.RoomType).FirstOrDefaultAsync(x => x.RoomType.Name == name);
        }

    }
}
