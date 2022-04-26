using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Models
{
    public class Payment
    {
        public string PaymentId { get; set; } = Guid.NewGuid().ToString();
       // public string Email { get; set; }
        public string Authorization_url { get; set; }
        public string Access_code { get; set; }
        public string Reference { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public string CreatedDate { get; set; } = DateTime.Now.ToString();
    }
}
