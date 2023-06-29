using BanMayTinh.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Module
{
    public class CateMenuViewComponent : ViewComponent
    {
        WebbanmaytinhContext db = new WebbanmaytinhContext();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = db.TblCategories.Where(c => c.IsDelete == 0 && c.IsActive == 1).ToList();
            return await Task.FromResult((IViewComponentResult)View("CateMenu", list));
        }
    }
}
