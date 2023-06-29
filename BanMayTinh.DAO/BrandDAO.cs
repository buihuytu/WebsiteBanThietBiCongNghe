using Azure;
using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.UTILITIES.Enums;
using BanMayTinh.UTILITIES.Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DAO
{
    public class BrandDAO
    {
        public static List<BrandEntity> GetAll(int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<BrandEntity>();
                list = (from b in context.TblBrands
                       where b.IsDelete == isDelete
                       select new BrandEntity()
                       {
                           BrandId = b.Id,
                           BrandName = b.Name,
                           Slug = b.Slug,
                           BrandImage = b.Image,
                           IdCategory = b.IdCategory,
                           CategoryName = (b.IdCategory == null ? "" : (from c in context.TblCategories where b.IdCategory == c.Id select c.Name).FirstOrDefault()),
                           MetaTitle = b.MetaTitle == null ? "" : b.MetaTitle,
                           MetaKey = b.MetaKey == null ? "" : b.MetaKey,
                           MetaDesc = b.MetaDesc == null ? "" : b.MetaDesc,
                           CreatedDate = b.CreatedDate,
                           CreatedBy = (b.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.CreatedBy select a.Username).FirstOrDefault()),
                           UpdatedDate = b.UpdatedDate,
                           UpdatedBy = (b.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.UpdatedBy select a.Username).FirstOrDefault()),
                           IsDelete = b.IsDelete,
                           IsActive = b.IsActive
                       }).ToList();
                return list;
            }
            
        }

        public static List<BrandEntity> GetAll(int page, int take, int isDelete)  
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<BrandEntity>();
                list = (from b in context.TblBrands
                        where b.IsDelete == isDelete
                        select new BrandEntity()
                        {
                            BrandId = b.Id,
                            BrandName = b.Name,
                            Slug = b.Slug,
                            BrandImage = b.Image,
                            IdCategory = b.IdCategory,
                            CategoryName = (b.IdCategory == null ? "" : (from c in context.TblCategories where b.IdCategory == c.Id select c.Name).FirstOrDefault()),
                            MetaTitle = b.MetaTitle == null ? "" : b.MetaTitle,
                            MetaKey = b.MetaKey == null ? "" : b.MetaKey,
                            MetaDesc = b.MetaDesc == null ? "" : b.MetaDesc,
                            CreatedDate = b.CreatedDate,
                            CreatedBy = (b.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = b.UpdatedDate,
                            UpdatedBy = (b.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = b.IsDelete,
                            IsActive = b.IsActive
                        }).Skip((page -1) * take).Take(take).ToList();
                return list;
            }

        }

        public static BrandEntity GetById(long id)
        {
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    var brand = (from b in context.TblBrands
                                 where b.Id == id
                                 select new BrandEntity()
                                 {
                                     BrandId = b.Id,
                                     BrandName = b.Name,
                                     Slug = b.Slug,
                                     BrandImage = b.Image,
                                     IdCategory = b.IdCategory,
                                     CategoryName = (b.IdCategory == null ? "" : (from c in context.TblCategories where b.IdCategory == c.Id select c.Name).FirstOrDefault()),
                                     MetaTitle = b.MetaTitle == null ? "" : b.MetaTitle,
                                     MetaKey = b.MetaKey == null ? "" : b.MetaKey,
                                     MetaDesc = b.MetaDesc == null ? "" : b.MetaDesc,
                                     CreatedDate = b.CreatedDate,
                                     CreatedBy = (b.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.CreatedBy select a.Username).FirstOrDefault()),
                                     UpdatedDate = b.UpdatedDate,
                                     UpdatedBy = (b.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.UpdatedBy select a.Username).FirstOrDefault()),
                                     IsDelete = b.IsDelete,
                                     IsActive = b.IsActive
                                 }).FirstOrDefault();
                    return brand;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<BrandEntity> GetBrandByName(string name, int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<BrandEntity>();
                list = (from b in context.TblBrands
                        where b.Name.Contains(name) && b.IsDelete == isDelete
                        select new BrandEntity()
                        {
                            BrandId = b.Id,
                            BrandName = b.Name,
                            Slug = b.Slug,
                            BrandImage = b.Image,
                            IdCategory = b.IdCategory,
                            CategoryName = (b.IdCategory == null ? "" : (from c in context.TblCategories where b.IdCategory == c.Id select c.Name).FirstOrDefault()),
                            MetaTitle = b.MetaTitle == null ? "" : b.MetaTitle,
                            MetaKey = b.MetaKey == null ? "" : b.MetaKey,
                            MetaDesc = b.MetaDesc == null ? "" : b.MetaDesc,
                            CreatedDate = b.CreatedDate,
                            CreatedBy = (b.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = b.UpdatedDate,
                            UpdatedBy = (b.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = b.IsDelete,
                            IsActive = b.IsActive
                        }).ToList();
                return list;
            }
        }

        public static List<BrandEntity> GetBrandByName(string name, int page, int take, int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<BrandEntity>();
                list = (from b in context.TblBrands
                        where b.Name.Contains(name) && b.IsDelete == isDelete
                        select new BrandEntity()
                        {
                            BrandId = b.Id,
                            BrandName = b.Name,
                            Slug = b.Slug,
                            BrandImage = b.Image,
                            IdCategory = b.IdCategory,
                            CategoryName = (b.IdCategory == null ? "" : (from c in context.TblCategories where b.IdCategory == c.Id select c.Name).FirstOrDefault()),
                            MetaTitle = b.MetaTitle == null ? "" : b.MetaTitle,
                            MetaKey = b.MetaKey == null ? "" : b.MetaKey,
                            MetaDesc = b.MetaDesc == null ? "" : b.MetaDesc,
                            CreatedDate = b.CreatedDate,
                            CreatedBy = (b.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = b.UpdatedDate,
                            UpdatedBy = (b.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == b.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = b.IsDelete,
                            IsActive = b.IsActive
                        }).Skip((page - 1) * take).Take(take).ToList();
                return list;
            }
        }

        public static int Create(BrandImage b)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string slugCategory = context.TblCategories.Where(c => c.Id == b.IdCategory).Select(c => c.Slug).FirstOrDefault();
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Brands\\";
                    string slug = XString.ToAscii(slugCategory + " " + b.Name);
                    CheckSlug check = new CheckSlug(context);
                    if(!check.KiemTraSlug("tblBrand", slug, null))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    var brand = new TblBrand
                    {
                        Name = b.Name,
                        Slug = slug,
                        IdCategory = b.IdCategory == 0 ? null : b.IdCategory,
                        MetaTitle = b.MetaTitle,
                        MetaKey = b.MetaKey,
                        MetaDesc = b.MetaDesc,
                        CreatedDate = DateTime.Now,
                        CreatedBy = b.CreatedBy,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = b.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = b.IsActive
                    };
                    if(b.FileImage != null)
                    {
                        string fileName = slug + b.FileImage.FileName.Substring(b.FileImage.FileName.LastIndexOf('.'));
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            b.FileImage.CopyTo(stream);
                        }
                        brand.Image = fileName;
                    }
                    else
                    {
                        brand.Image = null;
                    }
                    context.TblBrands.Add(brand);
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int Delete(long id)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Brands\\";
                    var brand = context.TblBrands.FirstOrDefault(b => b.Id == id);
                    if (brand != null)
                    {
                        string fileName = brand.Image;
                        File.Delete(route + fileName);
                        context.TblBrands.Remove(brand);
                        context.SaveChanges();
                        return (int)ReturnStatus.Success;
                    }
                    else
                    {
                        return (int)ReturnStatus.NotExists;
                    }
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int Update(long id, BrandImage b)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string slugCategory = context.TblCategories.Where(c => c.Id == b.IdCategory).Select(c => c.Slug).FirstOrDefault();
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Brands\\";
                    string slug = XString.ToAscii(slugCategory + " " +b.Name);
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblBrand", slug, id))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    var brand = new TblBrand
                    {
                        Id = id,
                        Name = b.Name,
                        Slug = slug,
                        IdCategory = b.IdCategory == 0 ? null : b.IdCategory,
                        MetaTitle = b.MetaTitle,
                        MetaKey = b.MetaKey,
                        MetaDesc = b.MetaDesc,
                        CreatedDate = (from br in context.TblBrands where br.Id == id select br.CreatedDate).FirstOrDefault(),
                        CreatedBy = (from br in context.TblBrands where br.Id == id select br.CreatedBy).FirstOrDefault(),
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = b.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = b.IsActive
                    };
                    string oldName = (from br in context.TblBrands where br.Id == id select br.Image).FirstOrDefault();
                    if (b.FileImage != null)
                    {
                        string fileName = slug + b.FileImage.FileName.Substring(b.FileImage.FileName.LastIndexOf('.'));
                        if(fileName != oldName && oldName!=null && File.Exists(route + oldName))
                        {
                            File.Delete(route + oldName);
                        }
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            b.FileImage.CopyTo(stream);
                        }
                        brand.Image = fileName;
                    }
                    else
                    {
                        string[] newNameImage = oldName.Split(".");
                        string newName = slug + "." + newNameImage[newNameImage.Length - 1];
                        if (newName != oldName && File.Exists(route + oldName))
                        {
                            File.Move(route + oldName, route + newName);
                            brand.Image = newName;
                        }
                        else
                        {
                            brand.Image = oldName;
                        }
                    }
                    context.Entry(brand).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int DelTrash(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblBrand brand = context.TblBrands.Find(id);
                    brand.IsDelete = 1;

                    brand.UpdatedDate = DateTime.Now;
                    brand.UpdatedBy = updatedBy;

                    context.Entry(brand).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int ReTrash(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblBrand brand = context.TblBrands.Find(id);
                    brand.IsDelete = 0;

                    brand.UpdatedDate = DateTime.Now;
                    brand.UpdatedBy = updatedBy;

                    context.Entry(brand).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int ChangeActive(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblBrand brand = context.TblBrands.Find(id);
                    brand.IsActive = (byte?)((brand.IsActive == 1) ? 0 : 1);
                    brand.UpdatedDate = DateTime.Now;
                    brand.UpdatedBy = updatedBy;
                    context.Entry(brand).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }
    }
}
