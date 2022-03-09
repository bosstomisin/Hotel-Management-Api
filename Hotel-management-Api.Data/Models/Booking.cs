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
        [DisplayName("Id")]
        public string BookingId { get; set; }
        public Room Room { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime CheckIn { get; set; } = DateTime.Now;
        public DateTime CheckOut { get; set; } = DateTime.Now;
        public int Guests { get; set; }
        public decimal TotalFee { get; set; }
        //public bool Paid { get; set; }
       // public bool Completed { get; set; }
        //public Guid UserId { get; set; }
        public  AppUser User { get; set; }
        public string CreatedDate { get; set; } = DateTime.Now.ToString();
        public string UpdatedDate { get; set; } = DateTime.Now.ToString();


    }
}
