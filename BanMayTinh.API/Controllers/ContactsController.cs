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
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("AllPage")]
        public IActionResult GetAllContacts(int page, int take, int isDelete)
        {
            var list = _contactService.GetAllContact(page, take, isDelete);
            int countContacts = _contactService.GetAllContact(isDelete).Count();
            int countTrash = _contactService.GetAllContact(1).Count();
            return StatusCode(StatusCodes.Status200OK, new { countTrash, countContacts, list });
        }

        [HttpGet("id")]
        public IActionResult GetContactById(long id)
        {
            ContactEntity contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            return StatusCode(StatusCodes.Status200OK, contact);
        }

        [HttpGet]
        [Route("GetByEmailPage")]
        public IActionResult GetContactByEmailPage(string email, int page, int take, int isDelete)
        {
            var list = _contactService.GetContactsByEmail(email, page, take, isDelete);
            int countContacts = _contactService.GetContactsByEmail(email, isDelete).Count();
            return StatusCode(StatusCodes.Status200OK, new { countContacts, list });
        }

        [HttpPost]
        public IActionResult CreateContact(TblContact contact)
        {
            int status = _contactService.CreateContact(contact);
            if (status == (int)ReturnStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, contact.FullName);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteContact(long id)
        {
            int status = _contactService.DeleteContact(id);
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
        public IActionResult ReplyContact(long id, TblContact contact)
        {
            int status = _contactService.ReplyContact(id, contact);
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
            int status = _contactService.DelTrash(id, updatedBy);
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
            int status = _contactService.ReTrash(id, updatedBy);
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
