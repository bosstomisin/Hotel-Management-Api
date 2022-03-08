using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Dto
{
    public class BaseResponse<T>
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get; set; }

        public T Data { get; set; }

    }
}
