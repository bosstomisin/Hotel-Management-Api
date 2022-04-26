using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Dto
{
    public class PaymentResponse
    {
        public string PaymentId { get; set; }
        public string Authorization_url { get; set; }
        public string Access_code { get; set; }
        public string Reference { get; set; }
        public string CreatedDate { get; set; }

    }
}
