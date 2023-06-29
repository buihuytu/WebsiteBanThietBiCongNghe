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
    public class NewsCategoryDAO
    {
        public static List<TblNewsCategory> getAll(int isDelete)
        {
            var list = new List<TblNewsCategory>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblNewsCategories.Where(nc => nc.IsDelete == isDelete).ToList();
            }
            return list;
        }

        public static List<TblNewsCategory> getAll(int page, int take, int isDelete)
        {
            var list = new List<TblNewsCategory>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblNewsCategories.Where(nc => nc.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static NewsCategoryEntity getById(long id)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var newsCategory = new NewsCategoryEntity();
                    newsCategory = (from nc in context.TblNewsCategories
                                    where nc.Id == id
                                    select new NewsCategoryEntity()
                                    {
                                        Id = nc.Id,
                                        Name = nc.Name,
                                        Notes = nc.Notes == null ? "" : nc.Notes,
                                        Icon = nc.Icon,
                                        ParentId = nc.IdParent,
                                        ParentName = (nc.IdParent == 0 ? "" : (from c in context.TblNewsCategories where c.Id == nc.IdParent select c.Name).FirstOrDefault()),
                                        Slug = nc.Slug,
                                        MetaTitle = nc.MetaTitle == null ? "" : nc.MetaTitle,
                                        MetaKey = nc.MetaKey == null ? "" : nc.MetaKey,
                                        MetaDesc = nc.MetaDesc == null ? "" : nc.MetaDesc,
                                        CreatedDate = nc.CreatedDate,
                                        CreatedName = (nc.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == nc.CreatedBy select a.Username).FirstOrDefault()),
                                        UpdatedDate = nc.UpdatedDate,
                                        UpdatedName = (nc.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == nc.UpdatedBy select a.Username).FirstOrDefault()),
                                        IsDelete = nc.IsDelete,
                                        IsActive = nc.IsActive
                                    }).FirstOrDefault();
                    return newsCategory;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<TblNewsCategory> getByName(string name, int isDelete)
        {
            try
            {
                var list = new List<TblNewsCategory>();
                using (var context = new WebbanmaytinhContext())
                {
                    list = context.TblNewsCategories.Where(r => r.Name.Contains(name) && r.IsDelete == isDelete).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<TblNewsCategory> getByName(string name, int page, int take, int isDelete)
        {
            try
            {
                var list = new List<TblNewsCategory>();
                using (var context = new WebbanmaytinhContext())
                {
                    list = context.TblNewsCategories.Where(r => r.Name.Contains(name) && r.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int Create(NewsCategoryImage nc)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\NewsCategories\\";
                    String slug = XString.ToAscii(nc.Name);
                    CheckSlug check = new CheckSlug(context);
                    if(!check.KiemTraSlug("tblNewsCategory", slug, null))
                    {
                        return (int)ReturnStatus.Exists;
                    }

                    var newsCategory = new TblNewsCategory() 
                    {
                        Name = nc.Name,
                        Notes = nc.Notes,
                        IdParent = nc.IdParent,
                        Slug = slug,
                        MetaTitle = nc.MetaTitle,
                        MetaKey = nc.MetaKey,
                        MetaDesc = nc.MetaDesc,
                        CreatedDate = DateTime.Now,
                        CreatedBy = nc.CreatedBy,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = nc.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = nc.IsActive,
                    };
                    
                    if(nc.FileImage != null)
                    {
                        string fileName = slug + nc.FileImage.FileName.Substring(nc.FileImage.FileName.LastIndexOf('.'));
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            nc.FileImage.CopyTo(stream);
                        }
                        newsCategory.Icon = fileName;
                    }
                    else
                    {
                        newsCategory.Icon = null;
                    }

                    context.TblNewsCategories.Add(newsCategory);
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                return (int)ReturnStatus.Exception;
            }
        }

        public static int Delete(long id) 
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var newsCategory = context.TblNewsCategories.SingleOrDefault(c => c.Id == id);
                    if (newsCategory != null)
                    {
                        context.TblNewsCategories.Remove(newsCategory);
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

        public static int Update(long id, NewsCategoryImage nc)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\NewsCategories\\";
                    String slug = XString.ToAscii(nc.Name);
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblNewsCategory", slug, id))
                    {
                        return (int)ReturnStatus.Exists;
                    }

                    var newsCategory = new TblNewsCategory()
                    {
                        Id = id,
                        Name = nc.Name,
                        Notes = nc.Notes,
                        IdParent = (nc.IdParent == null ? 0 : nc.IdParent),
                        Slug = slug,
                        MetaTitle = nc.MetaTitle,
                        MetaKey = nc.MetaKey,
                        MetaDesc = nc.MetaDesc,
                        CreatedDate = (from nct in context.TblNewsCategories where nct.Id == id select nct.CreatedDate).FirstOrDefault(),
                        CreatedBy = (from nct in context.TblNewsCategories where nct.Id == id select nct.CreatedBy).FirstOrDefault(),
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = nc.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = nc.IsActive,
                    };

                    string oldName = (from nct in context.TblNewsCategories where nct.Id == id select nct.Icon).FirstOrDefault();
                    if (nc.FileImage != null)
                    {
                        string fileName = slug + nc.FileImage.FileName.Substring(nc.FileImage.FileName.LastIndexOf('.'));
                        if (fileName != oldName && oldName != null && File.Exists(route + oldName))
                        {
                            File.Delete(route + oldName);
                        }
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            nc.FileImage.CopyTo(stream);
                        }
                        newsCategory.Icon = fileName;
                    }
                    else
                    {
                        string[] newNameImage = oldName.Split(".");
                        string newName = slug + "." + newNameImage[newNameImage.Length - 1];
                        if (newName != oldName && File.Exists(route + oldName))
                        {
                            File.Move(route + oldName, route + newName);
                            newsCategory.Icon = newName;
                        }
                        else
                        {
                            newsCategory.Icon = oldName;
                        }
                    }

                    context.Entry(newsCategory).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch(Exception ex)
            {
                return (int)ReturnStatus.Exception;
            }
        }

        public static int DelTrash(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblNewsCategory newsCategory = context.TblNewsCategories.Find(id);
                    newsCategory.IsDelete = 1;

                    newsCategory.UpdatedDate = DateTime.Now;
                    newsCategory.UpdatedBy = updatedBy;

                    context.Entry(newsCategory).State = EntityState.Modified;
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
                    TblNewsCategory newsCategory = context.TblNewsCategories.Find(id);
                    newsCategory.IsDelete = 0;

                    newsCategory.UpdatedDate = DateTime.Now;
                    newsCategory.UpdatedBy = updatedBy;

                    context.Entry(newsCategory).State = EntityState.Modified;
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
                    TblNewsCategory newsCategory = context.TblNewsCategories.Find(id);
                    newsCategory.IsActive = (byte?)((newsCategory.IsActive == 1) ? 0 : 1);
                    newsCategory.UpdatedDate = DateTime.Now;
                    newsCategory.UpdatedBy = updatedBy;
                    context.Entry(newsCategory).State = EntityState.Modified;
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
