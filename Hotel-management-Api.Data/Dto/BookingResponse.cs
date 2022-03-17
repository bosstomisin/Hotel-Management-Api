using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Dto
{
    public class BookingResponse
    {
        public string BookingId { get; set; }
        public string UserId { get; set; }
        public string RoomId { get; set; }
        public int Guests { get; set; }
        public decimal TotalFee { get; set; }
       // public string ExpectedCheckOutDate { get; set; }
        public string CheckOut { get; set; }
        public string CheckIn { get; set; }

        public string UpdatedDate { get; set; }
    }
}
