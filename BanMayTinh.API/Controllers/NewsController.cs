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
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        [Route("AllPage")]
        public IActionResult GetAllNewsPage(int page, int take, int isDelete)
        {
            var list = _newsService.getAllNews(page, take, isDelete);
            int countNews = _newsService.getAllNews(isDelete).Count();
            int countTrash = _newsService.getAllNews(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countNews, list });
        }

        [HttpGet("id")]
        public IActionResult GetNewsById (long id)
        {
            var news = _newsService.getNewsById(id);
            if(news == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            return StatusCode(StatusCodes.Status200OK, news);
        }

        [HttpGet]
        [Route("GetByNamePage")]
        public IActionResult GetNewsByName (string name, int page, int take, int isDelete) 
        {
            var list = _newsService.getNewsByName(name, page, take, isDelete);
            int countNews = _newsService.getNewsByName(name, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new {countNews, list});
        }

        [HttpPost]
        public IActionResult CreateNews([FromForm] NewsImage newsImage)
        {
            int status = _newsService.CreateNews(newsImage);
            if (status == (int)ReturnStatus.Exists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
            else if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, newsImage.Name);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteBrand(long id)
        {
            int status = _newsService.DeleteNews(id);
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
        public IActionResult UpdateBrand(long id, [FromForm] NewsImage news)
        {
            int status = _newsService.UpdateNews(id, news);
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
            int status = _newsService.DelTrash(id, updatedBy);
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
            int status = _newsService.ReTrash(id, updatedBy);
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
            int status = _newsService.ChangeActive(id, updatedBy);
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
