using BanMayTinh.BUS.IService;
using BanMayTinh.BUS.Service;
using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.UTILITIES.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BanMayTinh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCategoriesController : ControllerBase
    {
        private readonly INewsCategoryService _newsCategoryService;

        public NewsCategoriesController(INewsCategoryService newsCategoryService)
        {
            _newsCategoryService = newsCategoryService;
        }

        [HttpGet]
        public IActionResult GetAllNewsCategory()
        {
            var list = _newsCategoryService.GetAllNewsCategory(0);
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet]
        [Route("AllPage")]
        public IActionResult GetAllNewsCategoryPage(int page, int take, int isDelete)
        {
            var list = _newsCategoryService.GetAllNewsCategory(page, take, isDelete);
            int countNewsCategories = _newsCategoryService.GetAllNewsCategory(isDelete).Count();
            int countTrash = _newsCategoryService.GetAllNewsCategory(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countNewsCategories, list });
        }

        [HttpGet("id")]
        public IActionResult GetNewsCategoryById(long id) 
        {
            NewsCategoryEntity newsCategory = _newsCategoryService.GetNewsCategoryById(id);
            if (newsCategory == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            return StatusCode(StatusCodes.Status200OK, newsCategory);
        }

        [HttpGet]
        [Route("GetByNamePage")]
        public IActionResult GetNewsCategoryByName(string name, int page, int take, int isDelete) 
        {
            List<TblNewsCategory> list = _newsCategoryService.GetNewsCategoriesByName(name, page, take, isDelete);
            int countNewsCategories = _newsCategoryService.GetNewsCategoriesByName(name, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new { countNewsCategories, list });
        }

        [HttpPost]
        public IActionResult CreateNewsCategory([FromForm] NewsCategoryImage newsCategory)
        {
            int status = _newsCategoryService.AddNewsCategory(newsCategory);
            if (status == (int)ReturnStatus.Exists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
            else if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, newsCategory.Name);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateNewsCategory(long id, [FromForm] NewsCategoryImage newsCategory) 
        {
            int status = _newsCategoryService.EditNewsCategory(id, newsCategory);
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

        [HttpDelete("id")]
        public IActionResult DeleteNewsCategory(long id)
        {
            int status = _newsCategoryService.DeleteNewsCategory(id);
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
            int status = _newsCategoryService.DelTrash(id, updatedBy);
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
            int status = _newsCategoryService.ReTrash(id, updatedBy);
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
            int status = _newsCategoryService.ChangeActive(id, updatedBy);
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
