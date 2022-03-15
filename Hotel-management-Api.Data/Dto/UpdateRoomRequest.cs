using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Dto
{
    public class UpdateRoomRequest
    {
        public string RoomTypeName { get; set; }
        public int RoomNumber { get; set; }
        //public string UpdatedDate { get; set; } = DateTime.Now.ToString();
    }
}
