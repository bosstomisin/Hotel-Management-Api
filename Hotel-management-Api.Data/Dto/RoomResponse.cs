﻿using Hotel_management_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Dto
{
    public class RoomResponse
    {
        public string RoomId { get; set; }
        public string RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public decimal BasePrice { get; set; }
        public int RoomNumber { get; set; }
        public bool Available { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}
