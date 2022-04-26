﻿using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Repository.Interface
{
    public interface IPaymentRepo
    {
        Task<BaseResponse<Payment>> MakePayment(Payment payment)
    }
}
