﻿using Hotel_management_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Dto
{
    public class RoomRequest
    {
        public string RoomType { get; set; }
        public int RoomNumber { get; set; }
    }
}
