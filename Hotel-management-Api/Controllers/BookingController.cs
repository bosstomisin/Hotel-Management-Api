using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class BookingController : ControllerBase
    {
        private readonly IBookingService _booking;

        public BookingController(IBookingService booking)
        {
            _booking = booking;
        }

        [Authorize]
        [HttpPost("add-booking")]
        public async Task<BaseResponse<BookingResponse>> AddBooking(BookingRequest model)
        {
            return await _booking.AddBooking(model);
        }

        [HttpGet("get-bookings")]
        public BaseResponse<IEnumerable<BookingResponse>> GetBookings()
        {
           return _booking.GetAllBookings();
        }

        [HttpGet("get-booking/{id}")]
        public async Task<BaseResponse<BookingResponse>> GetBooking(string id)
        {
            return await  _booking.GetBooking(id);
        }

        [HttpDelete("delete-booking/{id}")]
        public async Task<BaseResponse<BookingResponse>> DeleteBooking(string id)
        {
            return await _booking.DeleteBooking(id);
        }
    }
}
