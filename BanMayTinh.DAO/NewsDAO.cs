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
    public class NewsDAO
    {
        public static List<NewsEntity> getAll(int isDelete)
        {
            List<NewsEntity> list = new List<NewsEntity>();
            using (var context = new WebbanmaytinhContext())
            {
                list = (from n in context.TblNews
                        where n.IsDelete == isDelete
                        select new NewsEntity()
                        {
                            NewsId = n.Id,
                            NewsName = n.Name,
                            NewsDescription = n.Description == null ? "" : n.Description,
                            NewsImage = n.Image,
                            NewsCategoryId = n.IdNewCategory,
                            NewsCategoryName = n.IdNewCategory == null ? "" : (from c in context.TblNewsCategories where c.Id == n.IdNewCategory select c.Name).FirstOrDefault(),
                            Contents = n.Contents == null ? "" : n.Contents,
                            Slug = n.Slug,
                            MetaTitle = n.MetaTitle == null ? "" : n.MetaTitle,
                            MetaKey = n.MetaKey == null ? "" : n.MetaKey,
                            MetaDesc = n.MetaDesc == null ? "" : n.MetaDesc,
                            CreatedDate = n.CreatedDate,
                            CreatedName = (n.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = n.UpdatedDate,
                            UpdatedName = (n.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = n.IsDelete,
                            IsActive = n.IsActive
                        }).ToList();
            }
            return list;
        }
        
        public static List<NewsEntity> getAll(int page, int take, int isDelete)
        {
            List<NewsEntity> list = new List<NewsEntity>();
            using (var context = new WebbanmaytinhContext())
            {
                list = (from n in context.TblNews
                        where n.IsDelete == isDelete
                        select new NewsEntity()
                        {
                            NewsId = n.Id,
                            NewsName = n.Name,
                            NewsDescription = n.Description == null ? "" : n.Description,
                            NewsImage = n.Image,
                            NewsCategoryId = n.IdNewCategory,
                            NewsCategoryName = n.IdNewCategory == null ? "" : (from c in context.TblNewsCategories where c.Id == n.IdNewCategory select c.Name).FirstOrDefault(),
                            Contents = n.Contents == null ? "" : n.Contents,
                            Slug = n.Slug,
                            MetaTitle = n.MetaTitle == null ? "" : n.MetaTitle,
                            MetaKey = n.MetaKey == null ? "" : n.MetaKey,
                            MetaDesc = n.MetaDesc == null ? "" : n.MetaDesc,
                            CreatedDate = n.CreatedDate,
                            CreatedName = (n.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = n.UpdatedDate,
                            UpdatedName = (n.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = n.IsDelete,
                            IsActive = n.IsActive
                        }).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static NewsEntity getById(long id)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var news = (from n in context.TblNews
                                where n.Id == id
                                select new NewsEntity()
                                {
                                    NewsId = n.Id,
                                    NewsName = n.Name,
                                    NewsDescription = n.Description == null ? "" : n.Description,
                                    NewsImage = n.Image,
                                    NewsCategoryId = n.IdNewCategory,
                                    NewsCategoryName = n.IdNewCategory == null ? "" : (from c in context.TblNewsCategories where c.Id == n.IdNewCategory select c.Name).FirstOrDefault(),
                                    Contents = n.Contents == null ? "" : n.Contents,
                                    Slug = n.Slug,
                                    MetaTitle = n.MetaTitle == null ? "" : n.MetaTitle,
                                    MetaKey = n.MetaKey == null ? "" : n.MetaKey,
                                    MetaDesc = n.MetaDesc == null ? "" : n.MetaDesc,
                                    CreatedDate = n.CreatedDate,
                                    CreatedName = (n.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.CreatedBy select a.Username).FirstOrDefault()),
                                    UpdatedDate = n.UpdatedDate,
                                    UpdatedName = (n.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.UpdatedBy select a.Username).FirstOrDefault()),
                                    IsDelete = n.IsDelete,
                                    IsActive = n.IsActive
                                }).FirstOrDefault();
                    return news;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<NewsEntity> getByName(string name, int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var news = (from n in context.TblNews
                            where n.Name.Contains(name) && n.IsDelete == isDelete
                            select new NewsEntity()
                            {
                                NewsId = n.Id,
                                NewsName = n.Name,
                                NewsDescription = n.Description == null ? "" : n.Description,
                                NewsImage = n.Image,
                                NewsCategoryId = n.IdNewCategory,
                                NewsCategoryName = n.IdNewCategory == null ? "" : (from c in context.TblNewsCategories where c.Id == n.IdNewCategory select c.Name).FirstOrDefault(),
                                Contents = n.Contents == null ? "" : n.Contents,
                                Slug = n.Slug,
                                MetaTitle = n.MetaTitle == null ? "" : n.MetaTitle,
                                MetaKey = n.MetaKey == null ? "" : n.MetaKey,
                                MetaDesc = n.MetaDesc == null ? "" : n.MetaDesc,
                                CreatedDate = n.CreatedDate,
                                CreatedName = (n.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.CreatedBy select a.Username).FirstOrDefault()),
                                UpdatedDate = n.UpdatedDate,
                                UpdatedName = (n.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.UpdatedBy select a.Username).FirstOrDefault()),
                                IsDelete = n.IsDelete,
                                IsActive = n.IsActive
                            }).ToList();
                return news;
            }
        }

        public static List<NewsEntity> getByName(string name, int page, int take, int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var news = (from n in context.TblNews
                            where n.Name.Contains(name) && n.IsDelete == isDelete
                            select new NewsEntity()
                            {
                                NewsId = n.Id,
                                NewsName = n.Name,
                                NewsDescription = n.Description == null ? "" : n.Description,
                                NewsImage = n.Image,
                                NewsCategoryId = n.IdNewCategory,
                                NewsCategoryName = n.IdNewCategory == null ? "" : (from c in context.TblNewsCategories where c.Id == n.IdNewCategory select c.Name).FirstOrDefault(),
                                Contents = n.Contents == null ? "" : n.Contents,
                                Slug = n.Slug,
                                MetaTitle = n.MetaTitle == null ? "" : n.MetaTitle,
                                MetaKey = n.MetaKey == null ? "" : n.MetaKey,
                                MetaDesc = n.MetaDesc == null ? "" : n.MetaDesc,
                                CreatedDate = n.CreatedDate,
                                CreatedName = (n.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.CreatedBy select a.Username).FirstOrDefault()),
                                UpdatedDate = n.UpdatedDate,
                                UpdatedName = (n.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == n.UpdatedBy select a.Username).FirstOrDefault()),
                                IsDelete = n.IsDelete,
                                IsActive = n.IsActive
                            }).Skip((page - 1) * take).Take(take).ToList();
                return news;
            }
        }

        public static int Create(NewsImage n)
        {
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\News\\";
                    string slug = XString.ToAscii(n.Name);
                    CheckSlug check = new CheckSlug(context);
                    if(!check.KiemTraSlug("tblNews", slug, null))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    var news = new TblNews
                    {
                        Name = n.Name,
                        Description = n.Description,
                        IdNewCategory = n.IdNewCategory,
                        Contents = n.Contents,
                        Slug = slug,
                        MetaTitle = n.MetaTitle,
                        MetaKey = n.MetaKey,
                        MetaDesc = n.MetaDesc,
                        CreatedDate = DateTime.Now,
                        CreatedBy = n.CreatedBy,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = n.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = n.IsActive
                    };
                    if(n.FileImage != null)
                    {
                        string fileName = slug + n.FileImage.FileName.Substring(n.FileImage.FileName.LastIndexOf('.'));
                        var path = Path.Combine(route, fileName);
                        using(var stream = File.Create(path))
                        {
                            n.FileImage.CopyTo(stream);
                        }
                        news.Image = fileName;
                    }
                    else
                    {
                        news.Image = null;
                    }
                    context.TblNews.Add(news);
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
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\News\\";
                    var news = context.TblNews.FirstOrDefault(n => n.Id == id);
                    if(news != null)
                    {
                        string fileName = news.Image;
                        File.Delete(route + fileName);
                        context.TblNews.Remove(news);
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

        public static int Update(long id, NewsImage n)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\News\\";
                    string slug = XString.ToAscii(n.Name);
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblNews", slug, id))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    var news = new TblNews
                    {
                        Id = id,
                        Name = n.Name,
                        Description = n.Description,
                        IdNewCategory = n.IdNewCategory,
                        Contents = n.Contents,
                        Slug = slug,
                        MetaTitle = n.MetaTitle,
                        MetaKey = n.MetaKey,
                        MetaDesc = n.MetaDesc,
                        CreatedDate = (from ns in context.TblNews where ns.Id == id select ns.CreatedDate).FirstOrDefault(),
                        CreatedBy = (from ns in context.TblNews where ns.Id == id select ns.CreatedBy).FirstOrDefault(),
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = n.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = n.IsActive
                    };
                    string oldName = (from ns in context.TblNews where ns.Id == id select ns.Image).FirstOrDefault();
                    if (n.FileImage != null)
                    {
                        string fileName = slug + n.FileImage.FileName.Substring(n.FileImage.FileName.LastIndexOf('.'));
                        if (fileName != oldName && oldName != null && File.Exists(route + oldName))
                        {
                            File.Delete(route + oldName);
                        }
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            n.FileImage.CopyTo(stream);
                        }
                        news.Image = fileName;
                    }
                    else
                    {
                        string[] newNameImage = oldName.Split(".");
                        string newName = slug + "." + newNameImage[newNameImage.Length - 1];
                        if (newName != oldName && File.Exists(route + oldName))
                        {
                            File.Move(route + oldName, route + newName);
                            news.Image = newName;
                        }
                        else
                        {
                            news.Image = oldName;
                        }
                    }
                    context.Entry(news).State = EntityState.Modified;
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
                    TblNews news = context.TblNews.Find(id);
                    news.IsDelete = 1;

                    news.UpdatedDate = DateTime.Now;
                    news.UpdatedBy = updatedBy;

                    context.Entry(news).State = EntityState.Modified;
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
                    TblNews news = context.TblNews.Find(id);
                    news.IsDelete = 0;

                    news.UpdatedDate = DateTime.Now;
                    news.UpdatedBy = updatedBy;

                    context.Entry(news).State = EntityState.Modified;
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
                    TblNews news = context.TblNews.Find(id);
                    news.IsActive = (byte?)((news.IsActive == 1) ? 0 : 1);
                    news.UpdatedDate = DateTime.Now;
                    news.UpdatedBy = updatedBy;
                    context.Entry(news).State = EntityState.Modified;
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
