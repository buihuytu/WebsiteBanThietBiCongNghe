using BanMayTinh.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.UTILITIES.Library
{
    public class CheckSlug
    {
        private readonly WebbanmaytinhContext _context;
        public CheckSlug(WebbanmaytinhContext context)
        {
            _context = context;
        }

        public bool KiemTraSlug(String Table, String Slug, long? id)
        {
            switch (Table)
            {
                case "tblCategory":
                    if (id != null)
                    {
                        if (_context.TblCategories.Where(m => m.Slug == Slug && m.Id != id).Count() > 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_context.TblCategories.Where(m => m.Slug == Slug).Count() > 0)
                            return false;
                    }
                    break;
                case "tblNewsCategory":
                    if (id != null)
                    {
                        if (_context.TblNewsCategories.Where(m => m.Slug == Slug && m.Id != id).Count() > 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_context.TblNewsCategories.Where(m => m.Slug == Slug).Count() > 0)
                            return false;
                    }
                    break;
                case "tblSlider":
                    if (id != null)
                    {
                        if (_context.TblSliders.Where(m => m.Url == Slug && m.Id != id).Count() > 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_context.TblSliders.Where(m => m.Url == Slug).Count() > 0)
                            return false;
                    }
                    break;
                case "tblBrand":
                    if (id != null)
                    {
                        if (_context.TblBrands.Where(m => m.Slug == Slug && m.Id != id).Count() > 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_context.TblBrands.Where(m => m.Slug == Slug).Count() > 0)
                            return false;
                    }
                    break;
                case "tblNews":
                    if (id != null)
                    {
                        if (_context.TblNews.Where(m => m.Slug == Slug && m.Id != id).Count() > 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_context.TblNews.Where(m => m.Slug == Slug).Count() > 0)
                            return false;
                    }
                    break;
                case "tblProduct":
                    if (id != null)
                    {
                        if (_context.TblProducts.Where(m => m.Slug == Slug && m.Id != id).Count() > 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_context.TblProducts.Where(m => m.Slug == Slug).Count() > 0)
                            return false;
                    }
                    break;
                case "tblAccount":
                    if (id != null)
                    {
                        if (_context.TblAccounts.Where(m => m.Username == Slug && m.Id != id).Count() > 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_context.TblAccounts.Where(m => m.Username == Slug).Count() > 0)
                            return false;
                    }
                    break;
            }
            return true;
        }
    }
}
