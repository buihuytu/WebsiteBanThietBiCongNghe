using BanMayTinh.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private WebbanmaytinhContext db = new WebbanmaytinhContext();

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Admin_Name") != null)
            {
                Response.Redirect("/Admin/Dashboard");
            }
            return View();
        }

        [HttpPost]
        public JsonResult Login(string User, string Pass)
        {
            int count_username = db.TblAccounts.Where(m => m.IsActive == 1 && m.Username == User && m.IsDelete == 0 && m.IdRole != 2).Count();
            if(count_username == 0)
            {
                return Json(new { s = 1 }); 
            }
            else
            {
                var admin_account = db.TblAccounts.Where(m => m.IsActive == 1 && m.IsDelete == 0 && m.IdRole != 2 && m.Username == User && m.Password == Pass);
                if(admin_account.Count() == 0 )
                {
                    return Json(new {s = 2});
                }
                else
                {
                    var admin = admin_account.First();
                    HttpContext.Session.SetString("Admin_Name", admin.Username);
                    HttpContext.Session.SetString("Admin_ID", admin.Id.ToString());
                    HttpContext.Session.SetString("Admin_Avatar", admin.Avatar == null ? "" : admin.Avatar);
                    HttpContext.Session.SetString("Admin_Address", admin.Address == null ? "" : admin.Address);
                    HttpContext.Session.SetString("Admin_Email", admin.Email == null ? "" : admin.Email);
                    HttpContext.Session.SetString("Admin_Phone", admin.Phone == null ? "" : admin.Phone);
                    HttpContext.Session.SetString("Admin_Role", (from r in db.TblRoles where r.Id == admin.IdRole select r.Name).FirstOrDefault().ToString());
                    return Json(new {s = 0});
                }
            }
        }

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetString("Admin_Name") != null)
            {
                HttpContext.Session.Remove("Admin_ID");
                HttpContext.Session.Remove("Admin_Name");
                HttpContext.Session.Remove("Admin_Avatar");
                HttpContext.Session.Remove("Admin_Address");
                HttpContext.Session.Remove("Admin_Email");
                HttpContext.Session.Remove("Admin_Phone");
                HttpContext.Session.Remove("Admin_Role");
            }
            return Redirect("/Admin/Login");
        }

    }
}
