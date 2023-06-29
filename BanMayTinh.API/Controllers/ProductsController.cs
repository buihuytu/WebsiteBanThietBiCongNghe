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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("AllPage")]
        public IActionResult GetAllProductsPage(int page, int take, int isDelete)
        {
            var list = _productService.GetAllProducts(page, take, isDelete);
            int countProducts = _productService.GetAllProducts(isDelete).Count();
            int countTrash = _productService.GetAllProducts(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countProducts, list });
        }

        [HttpGet("id")]
        public IActionResult GetProductById(long id)
        {
            var brand = _productService.GetProductById(id);
            if (brand == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            return StatusCode(StatusCodes.Status200OK, brand);
        }

        [HttpGet]
        [Route("GetByNamePage")]
        public IActionResult GetProductByNamePage(string name, int page, int take, int isDelete)
        {
            var list = _productService.GetProductByName(name, page, take, isDelete);
            int countProducts = _productService.GetProductByName(name, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new { countProducts, list });
        }

        [HttpPost]
        public IActionResult CreateProduct([FromForm] ProductImage product)
        {
            int status = _productService.CreateProduct(product);
            long id = _productService.GetIdByName(product.Name);
            if (status == (int)ReturnStatus.Exists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
            else if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, new { name = product.Name, id });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(long id)
        {
            int status = _productService.DeleteProduct(id);
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

        [HttpPut("id")]
        public IActionResult UpdateProduct(long id, [FromForm] ProductImage product)
        {
            int status = _productService.UpdateProduct(id, product);
            if (status == (int)ReturnStatus.Exists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
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
            int status = _productService.DelTrash(id, updatedBy);
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
            int status = _productService.ReTrash(id, updatedBy);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpPut("ChangeActive/{id}")]
        public IActionResult ChangeActive(long id, long updatedBy)
        {
            int status = _productService.ChangeActive(id, updatedBy);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpPut("ChangeDiscount/{id}")]
        public IActionResult ChangeDiscount(long id, long updatedBy)
        {
            int status = _productService.ChangeDiscount(id, updatedBy);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpPut("ChangeHotProduct/{id}")]
        public IActionResult ChangeHotProduct(long id, long updatedBy)
        {
            int status = _productService.ChangeHotProduct(id, updatedBy);
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
