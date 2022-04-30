using Hotel_management_Api.Data.Dto;
using Hotel_management_Api.Service.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel_management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _service;

        public PaymentController(PaymentService service)
        {
            _service = service;
        }
        public async Task<IActionResult> MakePayment(PaymentRequest request)
        {
            return Ok(await _service.MakePayment(request));
        }
    }
}
