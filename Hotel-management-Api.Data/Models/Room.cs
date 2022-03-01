using Hotel_management_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Models
{
    public class Room
    {
        public string RoomId { get; set; } = Guid.NewGuid().ToString();
        public RoomType RoomType { get; set; }
        public int RoomNumber { get; set; }
    }
}
