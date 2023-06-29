using BanMayTinh.BUS.IService;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.UTILITIES.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        [Route("GetImageProductPage")]
        public IActionResult GetListImageByProductId(long productId, int page, int take) 
        {
            var list = _productImageService.GetListImageByProductId(productId, page, take);
            int countImg = _productImageService.GetListImageByProductId(productId).Count();
            return StatusCode(StatusCodes.Status200OK, new {countImg, list});
        }

        [HttpPost]
        [Route("upload-single-image")]
        public IActionResult CreateSingleImage([FromForm] ImgProduct imageProduct)
        {
            int status = _productImageService.CreateSingleImage(imageProduct);
            if(status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, imageProduct.IdProduct);
            }
            else if(status == (int)ReturnStatus.NotPictureUploaded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e004");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpPost]
        [Route("upload-many-images")]
        public IActionResult CreateListImages([FromForm] ImgProduct imageProduct)
        {
            int status = _productImageService.CreateListImages(imageProduct);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, imageProduct.IdProduct);
            }
            else if (status == (int)ReturnStatus.NotPictureUploaded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e004");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpPut("id")]
        public IActionResult EditImage(long id, [FromForm] ImgProduct i)
        {
            int status = _productImageService.EditImage(id, i);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else if (status == (int)ReturnStatus.NotPictureUploaded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e004");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("productId/imageId")]
        public async Task<IActionResult> DeleteSingleImageByProductId(long productId, long imageId)
        {
            int status = _productImageService.DeleteSingleImageByProductId(productId, imageId);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, productId);
            }
            else if (status == (int)ReturnStatus.NotPictureUploaded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e004");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("productId")]
        public async Task<IActionResult> DeleteListImageByProductId(long productId)
        {
            int status = _productImageService.DeleteListImageByProductId(productId);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, productId);
            }
            else if (status == (int)ReturnStatus.NotPictureUploaded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e004");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
    }
}
