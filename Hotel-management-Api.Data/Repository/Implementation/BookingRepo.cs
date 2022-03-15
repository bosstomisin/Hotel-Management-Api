using Hotel_management_Api.Data.Models;
using Hotel_management_Api.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Repository.Implementation
{
    public class BookingRepo :  GenericRepo<Booking>, IBookingRepo
    {
        private readonly IRepository<Booking> _repo;

        public BookingRepo(DataContext context, IRepository<Booking> repo) : base(context)
        {
            _repo = repo;
        }
        
        
    }
}
