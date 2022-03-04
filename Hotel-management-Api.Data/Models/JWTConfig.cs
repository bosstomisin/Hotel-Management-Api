﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Models
{
    public class JWTConfig
    {
        public const string Data = "JWTConfig";
        public string SecretKey { get; set; }

        public TimeSpan TokenLifeTime { get; set; }


       // public string Issuer { get; set; }

      //  public string Audience { get; set; }
    }
}
