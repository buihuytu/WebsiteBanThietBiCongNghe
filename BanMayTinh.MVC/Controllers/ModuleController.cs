using BanMayTinh.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Controllers
{
    public class ModuleController : Controller
    {
        public IActionResult ICart()
        {
            return ViewComponent("_Cart");
        }
    }
}
