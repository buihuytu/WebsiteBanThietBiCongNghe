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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetAllBrands()
        {
            var listBrands = _brandService.GetAllBrands(0);
            return StatusCode(StatusCodes.Status200OK, listBrands);
        }

        [HttpGet]
        [Route("AllPage")]
        public IActionResult GetAllBrandsPage(int page, int take, int isDelete)
        {
            var list = _brandService.GetAllBrands(page, take, isDelete);
            int countBrands = _brandService.GetAllBrands(isDelete).Count();
            int countTrash = _brandService.GetAllBrands(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countBrands, list });
        }


        [HttpGet("id")]
        public IActionResult GetBrandById(long id) 
        {
            var brand = _brandService.GetBrandById(id);
            if(brand == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }    
            return StatusCode(StatusCodes.Status200OK, brand);
        }

        [HttpGet]
        [Route("GetByNamePage")]
        public IActionResult GetBrandByName(string name, int page, int take, int isDelete)
        {
            var list = _brandService.GetBrandByName(name, page, take, isDelete);
            int countBrands = _brandService.GetBrandByName(name, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new {countBrands, list});
        }

        [HttpPost]
        public IActionResult CreateBrand([FromForm] BrandImage brand)
        {
            int status = _brandService.CreateBrand(brand);
            if (status == (int)ReturnStatus.Exists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
            else if(status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, brand.Name);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteBrand(long id)
        {
            int status = _brandService.DeleteBrand(id);
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
        public IActionResult UpdateBrand(long id, [FromForm] BrandImage brand)
        {
            int status = _brandService.UpdateBrand(id, brand);
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
            int status = _brandService.DelTrash(id, updatedBy);
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
            int status = _brandService.ReTrash(id, updatedBy);
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
            int status = _brandService.ChangeActive(id, updatedBy);
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
