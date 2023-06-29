using BanMayTinh.BUS.IService;
using BanMayTinh.BUS.Service;
using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.UTILITIES.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("AllPage")]
        public IActionResult GetAllAccountsPage(int page, int take, int isDelete)
        {
            var list = _accountService.GetAllAccounts(page, take, isDelete);
            int countAccount = _accountService.GetAllAccounts(isDelete).Count();
            int countTrash = _accountService.GetAllAccounts((int)DeleteStatus.IsDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countAccount, list });
        }

        [HttpGet("id")]
        public IActionResult GetAccountById(long id) 
        {
            AccountEntity account = _accountService.GetAccountById(id);
            if(account == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            return StatusCode(StatusCodes.Status200OK, account);
        }

        [HttpGet]
        [Route("GetByUserNamePage")]
        public IActionResult GetAccountByUserNamePage(string username, int page, int take, int isDelete) 
        { 
            var list = _accountService.GetAccountByUserName(username, page, take, isDelete);
            int countAccount = _accountService.GetAccountByUserName(username, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new { countAccount , list});
        }

        [HttpGet("roleId")]
        public IActionResult GetAccountByRole(int roleId)
        {
            var list = _accountService.GetAccountByRole(roleId);
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpPost]
        public IActionResult AddAccount([FromForm] AccountImage account)
        {
            int status = _accountService.AddAccount(account);
            if (status == (int)ReturnStatus.Exists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
            else if(status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, account.Name);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteAccount(long id) 
        {
            int status = _accountService.DeleteAccount(id);
            if(status == (int)ReturnStatus.NotExists)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e003");
            }
            else if( status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, id);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateAccount(long id, [FromForm] AccountImage account)
        {
            int status = _accountService.UpdateAccount(id, account);
            if(status == (int)ReturnStatus.Exists)
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
            int status = _accountService.DelTrash(id, updatedBy);
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
            int status = _accountService.ReTrash(id, updatedBy);
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
            int status = _accountService.ChangeActive(id, updatedBy);
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
