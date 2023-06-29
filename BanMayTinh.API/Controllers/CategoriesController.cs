using BanMayTinh.BUS.IService;
using BanMayTinh.BUS.Service;
using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.UTILITIES.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BanMayTinh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var listCategory = _categoryService.GetAllCategories(0);
            return StatusCode(StatusCodes.Status200OK, listCategory);
        }

        [HttpGet("AllPage")]
        public IActionResult GetAllCategoriesInPage(int page, int take, int isDelete)
        {
            List<TblCategory> list = _categoryService.GetAllCategories(page, take, isDelete);
            int countCategory = _categoryService.GetAllCategories(isDelete).Count();
            int countTrash = _categoryService.GetAllCategories(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countCategory, list });
        }

        [HttpGet("id")]
        public IActionResult GetCategoryById(long id)
        {
            CategoryEntity category = _categoryService.GetCategoryById(id);
            if(category == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            return StatusCode(StatusCodes.Status200OK, category);

        }

        [HttpGet]
        [Route("GetByNamePage")]
        public IActionResult GetCategoryName(string name, int page, int take, int isDelete) 
        {
            List<TblCategory> list = _categoryService.GetCategoryByName(name, page, take, isDelete);
            int countCategory = _categoryService.GetCategoryByName(name, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new { countCategory, list});
        }

        [HttpPost]
        public IActionResult AddCategory([FromForm] CategoryImage category)
        {
            
            int status = _categoryService.AddCategory(category);
            if (status == (int)ReturnStatus.Exists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
            else if(status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, category.Name);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(long id)
        {
            int status = _categoryService.DeleteCategory(id);
            if(status == (int)ReturnStatus.NotExists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e003");
            }
            else if(status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateCategory(long id, [FromForm] CategoryImage category) 
        {
            int status = _categoryService.EditCategory(id, category);
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
            int status = _categoryService.DelTrash(id, updatedBy);
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
            int status = _categoryService.ReTrash(id, updatedBy);
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
            int status = _categoryService.ChangeActive(id, updatedBy);
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
