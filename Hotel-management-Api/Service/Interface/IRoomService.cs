using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_Api.Service.Interface
{
    public interface IRoomService 
    {
        Task<BaseResponse<RoomResponse>> AddRoom(RoomRequest room);

        Task<BaseResponse<RoomResponse>> GetRoom(string id);
        //Task<BaseResponse<bool>> DeleteRoom(string id);
        Task<BaseResponse<UpdateRoomResponse>> UpdateRoom(string id, UpdateRoomRequest model);
        BaseResponse<List<RoomResponse>> GetRooms();
    }
}
