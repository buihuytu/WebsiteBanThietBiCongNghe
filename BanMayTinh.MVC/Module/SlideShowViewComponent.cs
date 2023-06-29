using BanMayTinh.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BanMayTinh.UI.Module
{
    public class SlideShowViewComponent : ViewComponent
    {
        WebbanmaytinhContext db = new WebbanmaytinhContext();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = db.TblSliders.Where(s => s.IsDelete == 0 && s.IsActive == 1).ToList();
            return await Task.FromResult((IViewComponentResult)View("SlideShow", list));
        }
    }
}
