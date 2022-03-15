﻿using AutoMapper;
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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _repo;
        private readonly IMapper _map;

        public BookingService(IBookingRepo repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        public async Task<BaseResponse<BookingResponse>> AddBooking(BookingRequest model)
        {
            if (model == null)
            {
                return new BaseResponse<BookingResponse>() { Data = null, Message = "Model cannot be null", StatusCode = 204, Success = false };
            }
            var booking =_map.Map<Booking>(model);

            var addResponse = await _repo.InsertRecord(booking);
            if (!addResponse)
            {
                return new BaseResponse<BookingResponse>() { Data = null, Message = "Booking not created", StatusCode = 400, Success = false };
            }
            var bookingResponse = _map.Map<BookingResponse>(model);
            return new BaseResponse<BookingResponse>() { Data = bookingResponse, Message = "Booking Created", StatusCode = 201, Success = true };

        }
    }
}
