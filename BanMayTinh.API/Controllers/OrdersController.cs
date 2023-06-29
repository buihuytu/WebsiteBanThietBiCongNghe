using BanMayTinh.BUS.IService;
using BanMayTinh.BUS.Service;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.UTILITIES.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("AllPage")]
        public IActionResult GetAllOrdersPage(int page, int take, int isDelete)
        {
            var list = _orderService.GetAllOrders(page, take, isDelete);
            int countOrders = _orderService.GetAllOrders(isDelete).Count();
            int countTrash = _orderService.GetAllOrders(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countOrders, list });
        }

        [HttpGet]
        [Route("GetByNamePage")]
        public IActionResult GetOrdersByNamePage(string name, int page, int take, int isDelete)
        {
            var list = _orderService.GetOrdersByName(name, page, take, isDelete);
            int countOrders = _orderService.GetOrdersByName(name, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new { countOrders, list });
        }

        [HttpGet("id")]
        public IActionResult GetOrderById(long id) 
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            return StatusCode(StatusCodes.Status200OK, order);
        }

        [HttpDelete("id")]
        public IActionResult DeleteOrder(long id)
        {
            int status = _orderService.DeleteOrder(id);
            if (status == (int)ReturnStatus.NotExists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e003");
            }
            else if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }


        [HttpPut("DelTrash/{id}")]
        public IActionResult DelTrash(long id, long updatedBy)
        {
            int status = _orderService.DelTrash(id, updatedBy);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }


        [HttpPut("ReTrash/{id}")]
        public IActionResult ReTrash(long id, long updatedBy)
        {
            int status = _orderService.ReTrash(id, updatedBy);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpPut("ChangeStatus/{id}")]
        public IActionResult ChangeActive(long id, long updatedBy, int orderStatus)
        {
            int status = _orderService.ChangeStatus(id, updatedBy, orderStatus);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

    }
}
