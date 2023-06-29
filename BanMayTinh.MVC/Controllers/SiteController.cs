using BanMayTinh.DTO;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using System.Linq;
using System.Collections.Generic;

namespace BanMayTinh.UI.Controllers
{
    [Route("[action]/{slug?}")]
    public class SiteController : Controller
    {
        WebbanmaytinhContext db = new WebbanmaytinhContext();

        public IActionResult Home()
        {
            ViewBag.FlashSale = db.TblProducts.Where(p => p.IsDelete == 0 && p.IsActive == 1 && p.IsDiscount == 1).OrderByDescending(p => p.CreatedDate).Take(7).ToList();
            ViewBag.OutstandingLaptop = db.TblProducts.Where(p => p.IsDelete == 0 && p.IsActive == 1 && p.IsHotProduct == 1 && p.IdCategory == 1).OrderByDescending(p => p.CreatedDate).Take(7).ToList();
            ViewBag.OutstandingLaptopGaming = db.TblProducts.Where(p => p.IsDelete == 0 && p.IsActive == 1 && p.IsHotProduct == 1 && p.IdCategory == 2).OrderByDescending(p => p.CreatedDate).Take(7).ToList();
            ViewBag.OutstandingMonior = db.TblProducts.Where(p => p.IsDelete == 0 && p.IsActive == 1 && p.IsHotProduct == 1 && p.IdCategory == 3).OrderByDescending(p => p.CreatedDate).Take(7).ToList();
            ViewBag.OutstandingOther = db.TblProducts.Where(p => p.IsDelete == 0 && p.IsActive == 1 && p.IsHotProduct == 1 && p.IdCategory != 1 && p.IdCategory != 2 && p.IdCategory != 3).OrderByDescending(p => p.CreatedDate).Take(7).ToList();
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [Route("/collections/{slug}/{pageNumber:int?}")]
        public IActionResult ProductCategory(string slug, int? pageNumber)
        {
            int pageSize = 8;
            var row_cate = db.TblCategories.Where(m => m.Slug == slug).First();
            List<long> listcateid = new List<long>();
            listcateid.Add(row_cate.Id);    // danh sach id

            var list2 = db.TblCategories.Where(m => m.IdParent == row_cate.Id && m.IsDelete == 0 && m.IsActive == 1).Select(m => m.Id).ToList();    // con 1
            foreach(var id2 in list2){
                listcateid.Add(id2 );
                var list3 = db.TblCategories.Where(m => m.IdParent == id2 && m.IsDelete == 0 && m.IsActive == 1).Select(m => m.Id).ToList() ; // con 2
                foreach(var id3 in list3)
                {
                    listcateid.Add(id3);
                }
            }
            var list = db.TblProducts.Where(m => m.IsActive == 1 && m.IsDelete == 0 && listcateid.Contains((long)m.IdCategory)).OrderByDescending(m => m.CreatedDate);
            ViewBag.CountingTheProduct = list.Count();
            ViewBag.Slug = slug;
            ViewBag.CateName = row_cate.Name;

            return View("ProductCategory", list.ToPagedList(pageNumber ?? 1, pageSize));
        }

        [Route("/brand/{slug}/{pageNumber:int?}")]
        public IActionResult ProductBrand(string slug, int? pageNumber)
        {
            int pageSize = 8;
            var brand = db.TblBrands.Where(b => b.Slug == slug).FirstOrDefault();
            var listProducts = db.TblProducts.Where(p => p.IdBrand == brand.Id && p.IsDelete == 0 && p.IsActive == 1).OrderByDescending(p => p.CreatedDate);
            ViewBag.CountingTheProduct = listProducts.Count();
            ViewBag.Slug = slug;
            ViewBag.BrandName = brand.Name;
            ViewBag.ImageName = brand.Image;
            return View("ProductBrand", listProducts.ToPagedList(pageNumber ?? 1, pageSize));
        }

        [Route("/products/{slug}")]
        public IActionResult ProductDetail(string slug)
        {
            var product = db.TblProducts.Where(p => p.Slug == slug && p.IsDelete == 0 && p.IsActive == 1).First();
            ViewBag.ListPictures = db.TblProductImages.Where(p => p.IdProduct == product.Id).OrderByDescending(p => p.Id).ToList();
            ViewBag.CateSlug = db.TblCategories.Where(c => c.Id == product.IdCategory).Select(c => c.Slug).First();
            ViewBag.CateName = db.TblCategories.Where(c => c.Id == product.IdCategory).Select(c => c.Name).First();
            ViewBag.BrandName = db.TblBrands.Where(b => b.Id == product.IdBrand).Select(b => b.Name).First();
            ViewBag.listOther = db.TblProducts.Where(p => p.IsActive == 1 && p.IsDelete == 0 && p.IdCategory == product.IdCategory && p.Id != product.Id).Take(6).OrderByDescending(m => m.CreatedDate).ToList();
            return View("ProductDetail", product);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }
    }
}
