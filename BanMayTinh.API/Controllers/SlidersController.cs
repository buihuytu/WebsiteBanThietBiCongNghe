using BanMayTinh.BUS.IService;
using BanMayTinh.BUS.Service;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.UTILITIES.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BanMayTinh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult GetAllSliders(int isDelete) 
        {
            var list = _sliderService.GetAllSliders(isDelete);
            int countTrash = _sliderService.GetAllSliders(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, list });
        }

        [HttpGet]
        [Route("AllPage")]
        public IActionResult GetAllSlidersPage(int page, int take, int isDelete)
        {
            var list = _sliderService.GetAllSliders(page, take, isDelete);
            int countSliders = _sliderService.GetAllSliders(isDelete).Count();
            int countTrash = _sliderService.GetAllSliders(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countSliders, list });
        }

        [HttpGet("id")]
        public IActionResult GetSliderById(long id) 
        {
            var slider = _sliderService.GetSliderById(id);
            if (slider == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            return StatusCode(StatusCodes.Status200OK, slider);
        }

        [HttpGet]
        [Route("GetByNamePage")]
        public IActionResult GetSliderByName(string name, int page, int take, int isDelete) 
        {
            var list = _sliderService.GetSliderByName(name, page, take, isDelete);
            int countSliders = _sliderService.GetSliderByName(name, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new { countSliders , list});
        }

        [HttpPost]
        public IActionResult AddSlider([FromForm] SliderImage sliderImage)
        {
            int status = _sliderService.AddSlider(sliderImage);
            if (status == (int)ReturnStatus.Exists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
            else if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, sliderImage.Name);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteSlider(long id)
        {
            int status = _sliderService.DeleteSlider(id);
            if(status == (int)ReturnStatus.NotExists)
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
        public IActionResult UpdateSlider(long id, [FromForm] SliderImage sliderImage)
        {
            int status = _sliderService.UpdateSlider(id, sliderImage);
            if (status == (int)ReturnStatus.Success)
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
            int status = _sliderService.DelTrash(id, updatedBy);
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
            int status = _sliderService.ReTrash(id, updatedBy);
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
            int status = _sliderService.ChangeActive(id, updatedBy);
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
