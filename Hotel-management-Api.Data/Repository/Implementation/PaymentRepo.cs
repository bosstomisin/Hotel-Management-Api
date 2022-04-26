using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Data.Models;
using Hotel_management_Api.Data.Repository.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_Api.Data.Repository.Implementation
{
    public class PaymentRepo :IPaymentRepo
    {
        public async Task<BaseResponse<Payment>> MakePayment(Payment payment)
        {
            BaseResponse<Payment> paymentResponse;
            var url = "https://api.paystack.co/transaction/initialize";
            var request = JsonConvert.SerializeObject(payment);
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(url, content)) 
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    paymentResponse = JsonConvert.DeserializeObject<BaseResponse<Payment>>(contentResponse);
                }
            }
            return paymentResponse;
        }
    }
}
