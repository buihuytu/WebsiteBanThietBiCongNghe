using BanMayTinh.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Module
{
    public class OutstandingBrandViewComponent : ViewComponent
    {
        WebbanmaytinhContext db = new WebbanmaytinhContext();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = db.TblBrands.Where(s => s.IsDelete == 0 && s.IsActive == 1).Take(6).ToList();
            return await Task.FromResult((IViewComponentResult)View("OutstandingBrand", list));
        }
    }
}
