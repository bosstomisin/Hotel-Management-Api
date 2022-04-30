using AutoMapper;
using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Data.Models;
using Hotel_management_Api.Data.Repository.Interface;
using Hotel_management_Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Service.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo _repo;
        private readonly IMapper _map;
        private readonly IBookingRepo _bookingRepo;

        public PaymentService(IPaymentRepo repo, IMapper map, IBookingRepo bookingRepo)
        {
            _repo = repo;
            _map = map;
            _bookingRepo = bookingRepo;
        }
        public async Task<BaseResponse<PaymentResponse>> MakePayment(PaymentRequest request)
        {
            if (request == null)
            {
                return new BaseResponse<PaymentResponse>() { Data = null, Message = "Model cannot be null", StatusCode = 204, Success = false };
            }
            var getBooking = await _bookingRepo.GetRecord(request.BookingId);
            if (getBooking == null)
            {
                return new BaseResponse<PaymentResponse>() { Data = null, Message = "Booking does not exists", StatusCode = 404, Success = false };
            }
            var payment = _map.Map<PaymentRequest, Payment>(request);
            var response = await _repo.MakePayment(payment);
            if (!response.Success)
            {
                return new BaseResponse<PaymentResponse>() { Data = null, Message = "Payment was not successful", StatusCode = 400, Success = false };
            }
            var paymentResponse = _map.Map<Payment, PaymentResponse>(response.Data);
            return new BaseResponse<PaymentResponse>() { Data = paymentResponse, Message = "Payment successful", StatusCode = 200, Success = true };

        }
    }
}
