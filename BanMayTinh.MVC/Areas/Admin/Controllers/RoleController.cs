using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            var d = HttpContext.Session.GetString("Admin_Name") ?? "";
            if (d == null || d == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Trash()
        {
            var d = HttpContext.Session.GetString("Admin_Name") ?? "";
            if (d == null || d == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return View();
            }
        }
    }
}
