using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
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

        public IActionResult Detail(long id)
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

        public IActionResult Delete(long id)
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

        public IActionResult Create()
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

        public IActionResult Edit(long id)
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
