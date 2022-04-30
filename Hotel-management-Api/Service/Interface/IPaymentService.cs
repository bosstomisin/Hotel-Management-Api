using Hotel_management_Api.Data.Dto;
using System.Threading.Tasks;

namespace Hotel_management_Api.Service.Interface
{
    public interface IPaymentService
    {
        Task<BaseResponse<PaymentResponse>> MakePayment(PaymentRequest request);
    }
}
