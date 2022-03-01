﻿using Hotel_management_Api.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Address AddressId { get; set; }
        public Address Address { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
