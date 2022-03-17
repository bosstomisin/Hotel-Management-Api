using Hotel_management_Api.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Service.Interface
{
    public interface IBookingService
    {
        Task<BaseResponse<BookingResponse>> AddBooking(BookingRequest model);
        BaseResponse<IEnumerable<BookingResponse>> GetAllBookings();
        Task<BaseResponse<BookingResponse>> GetBooking(string id);
        Task<BaseResponse<BookingResponse>> DeleteBooking(string id);
        Task<BaseResponse<UpdateBookingResponse>> UpdateBooking(string id, BookingRequest model);
    }
}
