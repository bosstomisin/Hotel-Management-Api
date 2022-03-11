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
        private readonly IRepository<Room> _repo;
        public RoomRepo(DataContext context, IRepository<Room> repo ) : base(context)
        {
            _repo = repo;
        }
        public async Task<Room> GetByName(string name)
        {
            return await _ctx.Room.Include(s => s.RoomType).FirstOrDefaultAsync(x => x.RoomType.Name == name);
        }

        public IQueryable<Room> GetAllRooms()
        {
            return _repo.GetRecords().Include(x => x.RoomType);
        }

    }
}
