using Hotel_management_Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Models
{
    public class Booking
    {
        //[DisplayName("Id")]
        public string BookingId { get; set; } = Guid.NewGuid().ToString();
        public string RoomId { get; set; }
        public Room Room { get; set; }
        public int Guests { get; set; }
        public decimal TotalFee { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string CheckIn { get; set; } = DateTime.Now.ToString();
        public string ExpectedCheckOutDate { get; set; }
        public string CheckOut { get; set; } = DateTime.Now.ToString();
        public string UpdatedDate { get; set; } = DateTime.Now.ToString();


    }
}
