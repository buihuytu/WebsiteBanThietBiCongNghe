using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Module
{
    public class LoginMenuViewComponent :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("LoginMenu"));
        }
    }
}
