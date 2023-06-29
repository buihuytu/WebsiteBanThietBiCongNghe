using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Module
{
    public class _CartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_Cart"));
        }
    }
}
