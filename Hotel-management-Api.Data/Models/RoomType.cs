using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Models
{
    public class RoomType
    {
        public string RoomTypeId { get; set; } = Guid.NewGuid().ToString();
        public string RoomTypeName { get; set; }
        public decimal BasePrice { get; set; }

    }
}
