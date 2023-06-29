using BanMayTinh.DTO;
using BanMayTinh.UTILITIES.Library;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Controllers
{
    public class AccountController : Controller
    {
        private WebbanmaytinhContext db = new WebbanmaytinhContext();

        [HttpPost]
        public JsonResult UserLogin(string User, string Password)
        {
            int count_username = db.TblAccounts.Where(a => a.IsActive == 1 && a.IsDelete == 0 && a.IdRole == 2 && (a.Phone == User || a.Email == User || a.Username == User)).Count();
            if(count_username == 0)
            {
                return Json(new { s = 1 });
            }
            else
            {
                // Password = XString.ToMD5(Password);
                var user_account = db.TblAccounts.Where(a => a.IsActive == 1 && a.IsDelete == 0 && a.IdRole == 2 && (a.Phone == User || a.Email == User || a.Username == User) && a.Password == Password);
                if(user_account.Count() == 0)
                {
                    return Json(new { s = 2 });
                }
                else
                {
                    var user = user_account.First();
                    HttpContext.Session.SetString("User_Name", user.Username);
                    HttpContext.Session.SetString("User_ID", user.Id.ToString());
                }
            }
            return Json(new { s = 0 });
        }

        public ActionResult UserLogout(String url)
        {
            HttpContext.Session.Remove("User_Name");
            HttpContext.Session.Remove("User_ID");
            return Redirect("~" + url);
        }

        public ActionResult Register(TblAccount user) 
        {
            try
            {
                var checkPM = db.TblAccounts.Any(m => m.Phone == user.Phone && m.Email.ToLower().Equals(user.Email.ToLower()));
                if (checkPM)
                {
                    return Json(new { Code = 1, Message = "Số điện thoại hoặc Email đã được sử dụng." });
                }
                user.Avatar = "";
                user.IdRole = 2;
                user.IsActive = 1;
                user.IsDelete = 0;
                //user.Password = XString.ToMD5(user.Password);
                user.Password = user.Password;
                user.CreatedDate = DateTime.Now;
                user.CreatedBy = 4;
                user.UpdatedDate = DateTime.Now;
                user.UpdatedBy = 1;

                db.TblAccounts.Add(user);
                db.SaveChanges();

                return Json(new { Code = 0, Message = "Đăng ký thành công!" });
            }
            catch (Exception e)
            {
                return Json(new { Code = 1, Message = "Đăng ký thất bại!" });
                throw e;
            }
        }


    }
}
