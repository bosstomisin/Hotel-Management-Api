using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Dto
{
    public class LoginResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
