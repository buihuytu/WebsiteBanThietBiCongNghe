using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BanMayTinh.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            var d = HttpContext.Session.GetString("Admin_Name") ?? "";
            if (d == null || d == "") 
            {
                HttpContext.Response.Redirect("~/Admin/Login");
            }
        }
    }
}
