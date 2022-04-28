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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _repo;
        private readonly IMapper _map;
        private readonly IUserService _userService;

        public BookingService(IBookingRepo repo, IMapper map, IUserService userService)
        {
            _repo = repo;
            _map = map;
            _userService = userService;
        }

        public async Task<BaseResponse<BookingResponse>> AddBooking(BookingRequest model)
        {
            if (model == null)
            {
                return new BaseResponse<BookingResponse>() { Data = null, Message = "Model cannot be null", StatusCode = 204, Success = false };
            }
           // var getUser = _userService.
            var booking =_map.Map<Booking>(model);

            var addResponse = await _repo.InsertRecord(booking);
            
            if (!addResponse)
            {
                return new BaseResponse<BookingResponse>() { Data = null, Message = "Booking not created", StatusCode = 400, Success = false };
            }
            var bookingResponse = _map.Map<BookingResponse>(booking);
            return new BaseResponse<BookingResponse>() { Data = bookingResponse, Message = "Booking Created", StatusCode = 201, Success = true };
            
        }
        
        public  BaseResponse<IEnumerable<BookingResponse>> GetAllBookings()
        {
            var records =_repo.GetRecords();
            if (records == null)
            {
                return new BaseResponse<IEnumerable<BookingResponse>>() { Data = null, Message = "No record", StatusCode = 404, Success = false };
            }
            var bookingRespose = _map.Map<IEnumerable<BookingResponse>>(records);
            return new BaseResponse<IEnumerable<BookingResponse>>() { Data = bookingRespose, Message = "Successful", StatusCode = 200, Success = true };

        }

        public async Task<BaseResponse<BookingResponse>> GetBooking(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return new BaseResponse<BookingResponse>() { Data = null, Message = "Incorrect id", StatusCode = 404, Success = false };
            }
            var booking = await _repo.GetRecord(id);
            if (booking == null)
            {
                return new BaseResponse<BookingResponse>() { Data = null, Message = "Record not found", StatusCode = 404, Success = false };
            }
            var bookingResponse = _map.Map<BookingResponse>(booking);
            return new BaseResponse<BookingResponse>() { Data = bookingResponse, Message = "Successful", StatusCode = 200, Success = true };

        }

        public async Task<BaseResponse<BookingResponse>> DeleteBooking(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return new BaseResponse<BookingResponse>() { Data = null, Message = "Incorrect id", StatusCode = 404, Success = false };
            }
            var booking = await _repo.GetRecord(id);
            if (booking == null)
            {
                return new BaseResponse<BookingResponse>() { Data = null, Message = "Booking not found", StatusCode = 404, Success = false };
            }
            var deleteResponse = await _repo.DeleteRecord(id);
            if (!deleteResponse)
            {
                return new BaseResponse<BookingResponse>() { Data = null, Message = "Operation not Successful", StatusCode = 400, Success = false };
            }
            var bookingResponse = _map.Map<BookingResponse>(booking);
            return new BaseResponse<BookingResponse>() { Data = bookingResponse, Message = "Successful", StatusCode = 200, Success = true };

        }

        public async Task<BaseResponse<UpdateBookingResponse>> UpdateBooking(string id, BookingRequest model)
        {
            if (string.IsNullOrWhiteSpace(id) || model == null)
            {
                return new BaseResponse<UpdateBookingResponse>() { Data = null, Message = "Incorrect id", StatusCode = 404, Success = false };
            }
            var booking = await _repo.GetRecord(id);
            if (booking == null)
            {
                return new BaseResponse<UpdateBookingResponse>() { Data = null, Message = "Booking not found", StatusCode = 404, Success = false };
            }
            booking = _map.Map(model, booking);
            booking.UpdatedDate = DateTime.Now.ToString();
            var updateResponse = await _repo.UpdateRecord(booking);
            if (!updateResponse)
            {
                return new BaseResponse<UpdateBookingResponse>() { Data = null, Message = "Operation not Successful", StatusCode = 400, Success = false };
            }
            var bookingResponse = _map.Map<UpdateBookingResponse>(booking);
            return new BaseResponse<UpdateBookingResponse>() { Data = bookingResponse, Message = "Successful", StatusCode = 200, Success = true };

        }
    }
}
