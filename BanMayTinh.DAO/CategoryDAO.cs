using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.UTILITIES.Enums;
using BanMayTinh.UTILITIES.Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DAO
{
    public class CategoryDAO
    {
        public static List<TblCategory> getAll(int isDelete)
        {
            List<TblCategory> list = new List<TblCategory>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblCategories.Where(c => c.IsDelete == isDelete).ToList();
            }
            return list;
        }

        public static List<TblCategory> getAll(int page, int take, int isDelete)
        {
            List<TblCategory> list = new List<TblCategory>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblCategories.Where(c => c.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static CategoryEntity getCategoryById(long id) 
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var category = (from c in context.TblCategories
                                    where c.Id == id
                                    select new CategoryEntity()
                                    {
                                        Id = c.Id,
                                        Name = c.Name,
                                        Notes = c.Notes == null ? "" : c.Notes,
                                        Icon = c.Icon,
                                        ParentId = c.IdParent,
                                        ParentName = (c.IdParent == 0 ? "" : (from ct in context.TblCategories where ct.Id == c.IdParent select ct.Name).FirstOrDefault()),
                                        Slug = c.Slug,
                                        MetaTitle = c.MetaTitle == null ? "" : c.MetaTitle,
                                        MetaKey = c.MetaKey == null ? "" : c.MetaKey,
                                        MetaDesc = c.MetaDesc == null ? "" : c.MetaDesc,
                                        CreatedDate = c.CreatedDate,
                                        CreatedName = (c.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == c.CreatedBy select a.Username).FirstOrDefault()),
                                        UpdatedDate = c.UpdatedDate,
                                        UpdatedName = (c.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == c.UpdatedBy select a.Username).FirstOrDefault()),
                                        IsDelete = c.IsDelete,
                                        IsActive = c.IsActive
                                    }).FirstOrDefault();
                    return category;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public static List<TblCategory> getCategoryByName(string name, int isDelete)
        {
            List<TblCategory> list = new List<TblCategory>();
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    list = context.TblCategories.Where(c => c.Name.Contains(name) && c.IsDelete == isDelete).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<TblCategory> getCategoryByName(string name, int page, int take, int isDelete)
        {
            List<TblCategory> list = new List<TblCategory>();
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    list = context.TblCategories.Where(c => c.Name.Contains(name) && c.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int AddCategory(CategoryImage c)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Categories\\";
                    String slug = XString.ToAscii(c.Name);
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblCategory", slug, null))
                    {
                        return (int)ReturnStatus.Exists;
                    }

                    var category = new TblCategory
                    {
                        Name = c.Name,
                        Notes = c.Notes,
                        IdParent = (c.IdParent == null ? 0 : c.IdParent),
                        Slug = slug,
                        MetaTitle = c.MetaTitle,
                        MetaKey = c.MetaKey,
                        MetaDesc = c.MetaDesc,
                        CreatedDate = DateTime.Now,
                        CreatedBy = c.CreatedBy,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = c.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = c.IsActive,
                    };

                    if(c.FileImage != null)
                    {
                        string fileName = slug + c.FileImage.FileName.Substring(c.FileImage.FileName.LastIndexOf('.'));
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path)) 
                        {
                            c.FileImage.CopyTo(stream);
                        }
                        category.Icon = fileName;
                    }
                    else
                    {
                        category.Icon = null;
                    }

                    context.TblCategories.Add(category);
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                return (int)ReturnStatus.Exception;
            }

        }

        public static int DeleteCategory(long id)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Categories\\";
                    var category = context.TblCategories.SingleOrDefault(c => c.Id == id);
                    if (category != null)
                    {
                        string fileName = category.Icon;
                        File.Delete(route + fileName);
                        context.TblCategories.Remove(category);
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
                return (int)ReturnStatus.Exception;
            }
        }

        public static int EditCategory(long id, CategoryImage c)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Categories\\";
                    String slug = XString.ToAscii(c.Name);
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblCategory", slug, id))
                    {
                        return (int)ReturnStatus.Exists;
                    }

                    var category = new TblCategory
                    {
                        Id = id,
                        Name = c.Name,
                        Notes = c.Notes,
                        IdParent = (c.IdParent == null ? 0 : c.IdParent),
                        Slug = slug,
                        MetaTitle = c.MetaTitle,
                        MetaKey = c.MetaKey,
                        MetaDesc = c.MetaDesc,
                        CreatedDate = (from ct in context.TblCategories where ct.Id == id select ct.CreatedDate).FirstOrDefault(),
                        CreatedBy = (from ct in context.TblCategories where ct.Id == id select ct.CreatedBy).FirstOrDefault(),
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = c.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = c.IsActive,
                    };

                    string oldName = (from ct in context.TblCategories where ct.Id == id select ct.Icon).FirstOrDefault();
                    if (c.FileImage != null)
                    {
                        string fileName = slug + c.FileImage.FileName.Substring(c.FileImage.FileName.LastIndexOf('.'));
                        if (fileName != oldName && oldName != null && File.Exists(route + oldName))
                        {
                            File.Delete(route + oldName);
                        }
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            c.FileImage.CopyTo(stream);
                        }
                        category.Icon = fileName;
                    }
                    else
                    {
                        string[] newNameImage = oldName.Split(".");
                        string newName = slug + "." + newNameImage[newNameImage.Length - 1];
                        if (newName != oldName && File.Exists(route + oldName))
                        {
                            File.Move(route + oldName, route + newName);
                            category.Icon = newName;
                        }
                        else
                        {
                            category.Icon = oldName;
                        }
                    }

                    context.Entry(category).State = EntityState.Modified;
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
                using(var context = new WebbanmaytinhContext())
                {
                    TblCategory category = context.TblCategories.Find(id);
                    category.IsDelete = 1;

                    category.UpdatedDate = DateTime.Now;
                    category.UpdatedBy = updatedBy;

                    context.Entry(category).State = EntityState.Modified;
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
                    TblCategory category = context.TblCategories.Find(id);
                    category.IsDelete = 0;

                    category.UpdatedDate = DateTime.Now;
                    category.UpdatedBy = updatedBy;

                    context.Entry(category).State = EntityState.Modified;
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
            try{
                using (var context = new WebbanmaytinhContext())
                {
                    TblCategory category = context.TblCategories.Find(id);
                    category.IsActive = (byte?)((category.IsActive == 1) ? 0 : 1);
                    category.UpdatedDate = DateTime.Now;
                    category.UpdatedBy = updatedBy;
                    context.Entry(category).State = EntityState.Modified;
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
