using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        public IActionResult Index(int id)
        {
            var d = HttpContext.Session.GetString("Admin_Name") ?? "";
            if (d == null || d == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                ViewBag.Id = id;
                return View();
            }
        }       
    }
}
