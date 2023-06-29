using BanMayTinh.BUS.IService;
using BanMayTinh.BUS.Service;
using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.UTILITIES.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            List<TblRole> list = _roleService.GetAllRoles(0);
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet]
        [Route("AllPage")]
        public IActionResult GetAllRolesPage(int page, int take, int isDelete)
        {
            List<TblRole> list = _roleService.GetAllRoles(page, take, isDelete);
            int countRoles = _roleService.GetAllRoles(isDelete).Count();
            int countTrash = _roleService.GetAllRoles(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countRoles, list });
        }

        [HttpGet("id")]
        public IActionResult GetRoleById (long id) 
        {
            RoleEntity role = _roleService.GetRoleById(id);
            if(role == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            return StatusCode(StatusCodes.Status200OK, role);
        }

        [HttpGet]
        [Route("GetByNamePage")]
        public IActionResult GetRoleByName(string name, int page, int take, int isDelete) 
        {
            List<TblRole> list = _roleService.GetRolesByName(name, page, take, isDelete);
            int countRoles = _roleService.GetRolesByName(name, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new {countRoles, list});
        }

        [HttpPost]
        public IActionResult CreateRole (TblRole role) 
        {
            int status = _roleService.AddRole(role);
            if (status == (int)ReturnStatus.Exists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
            else if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, role.Name);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteRole (long id)
        {
            int status = _roleService.DeleteRole(id);
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
        public IActionResult UpdateRole (long id, TblRole role) 
        {
            int status = _roleService.EditRole(id, role);
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
            int status = _roleService.DelTrash(id, updatedBy);
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
            int status = _roleService.ReTrash(id, updatedBy);
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
            int status = _roleService.ChangeActive(id, updatedBy);
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
