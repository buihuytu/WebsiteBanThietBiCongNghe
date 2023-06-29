using BanMayTinh.BUS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("orderId")]
        public IActionResult GetDetailByOrderId(long orderId) 
        {
            var list = _orderDetailService.GetAllOrderDetail(orderId);
            return StatusCode(StatusCodes.Status200OK, list);
        }
    }
}
