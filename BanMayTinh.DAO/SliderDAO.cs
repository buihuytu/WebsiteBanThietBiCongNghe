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
    public class SliderDAO
    {
        public static List<SliderEntity> getAll(int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<SliderEntity>();
                list = (from s in context.TblSliders
                        where s.IsDelete == isDelete
                        select new SliderEntity()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Url = s.Url,
                            Description = s.Description == null ? "" : s.Description,
                            Position = "Home",
                            Image = s.Image,
                            CreatedDate = s.CreatedDate,
                            CreatedBy = (s.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = s.UpdatedDate,
                            UpdatedBy = (s.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = s.IsDelete,
                            IsActive = s.IsActive,
                        }).ToList();

                return list;
            }
        }

        public static List<SliderEntity> getAll(int page, int take, int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<SliderEntity>();
                list = (from s in context.TblSliders
                        where s.IsDelete == isDelete
                        select new SliderEntity()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Url = s.Url,
                            Description = s.Description == null ? "" : s.Description,
                            Position = "Home",
                            Image = s.Image,
                            CreatedDate = s.CreatedDate,
                            CreatedBy = (s.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = s.UpdatedDate,
                            UpdatedBy = (s.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = s.IsDelete,
                            IsActive = s.IsActive,
                        }).Skip((page - 1) * take).Take(take).ToList();

                return list;
            }
        }

        public static SliderEntity getById(long id) 
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var slider = new SliderEntity();
                    slider = (from s in context.TblSliders
                              where s.Id == id
                              select new SliderEntity()
                              {
                                  Id = s.Id,
                                  Name = s.Name,
                                  Url = s.Url,
                                  Description = s.Description == null ? "" : s.Description,
                                  Position = "Home",
                                  Image = s.Image,
                                  CreatedDate = s.CreatedDate,
                                  CreatedBy = (s.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.CreatedBy select a.Username).FirstOrDefault()),
                                  UpdatedDate = s.UpdatedDate,
                                  UpdatedBy = (s.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.UpdatedBy select a.Username).FirstOrDefault()),
                                  IsDelete = s.IsDelete,
                                  IsActive = s.IsActive,
                              }).FirstOrDefault();
                    return slider;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<SliderEntity> getByName(string name, int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<SliderEntity>();
                list = (from s in context.TblSliders
                        where s.Name.Contains(name) && s.IsDelete == isDelete
                        select new SliderEntity()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Url = s.Url,
                            Description = s.Description == null ? "" : s.Description,
                            Position = "Home",
                            Image = s.Image,
                            CreatedDate = s.CreatedDate,
                            CreatedBy = (s.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = s.UpdatedDate,
                            UpdatedBy = (s.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = s.IsDelete,
                            IsActive = s.IsActive,
                        }).ToList();
                return list;
            }
        }

        public static List<SliderEntity> getByName(string name, int page, int take, int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<SliderEntity>();
                list = (from s in context.TblSliders
                        where s.Name.Contains(name) && s.IsDelete == isDelete
                        select new SliderEntity()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Url = s.Url,
                            Description = s.Description == null ? "" : s.Description,
                            Position = "Home",
                            Image = s.Image,
                            CreatedDate = s.CreatedDate,
                            CreatedBy = (s.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = s.UpdatedDate,
                            UpdatedBy = (s.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == s.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = s.IsDelete,
                            IsActive = s.IsActive,
                        }).Skip((page - 1) * take).Take(take).ToList();
                return list;
            }
        }

        public static int Add(SliderImage s)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Sliders\\";
                    String slug = XString.ToAscii(s.Name);
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblSlider", slug, null))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    var slider = new TblSlider
                    {
                        Name = s.Name,
                        Url = slug,
                        Description = s.Description,
                        Position = s.Position,
                        CreatedDate = DateTime.Now,
                        CreatedBy = s.CreatedBy,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = s.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = s.IsActive,
                    };
                    if (s.FileImage != null)
                    {
                        String fileName = slug + s.FileImage.FileName.Substring(s.FileImage.FileName.LastIndexOf('.'));
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            s.FileImage.CopyTo(stream);
                        }
                        slider.Image = fileName;
                    }
                    else
                    {
                        slider.Image = null;
                    }
                    context.TblSliders.Add(slider);
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
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Sliders\\";
                    var slider = context.TblSliders.SingleOrDefault(c => c.Id == id);
                    if (slider != null)
                    {
                        string fileName = slider.Image;
                        File.Delete(route + fileName);
                        context.TblSliders.Remove(slider);
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

        public static int Update(long id, SliderImage s)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    String slug = XString.ToAscii(s.Name);
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblSlider", slug, id))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Sliders\\";
                    var slider = new TblSlider
                    {
                        Id = id,
                        Name = s.Name,
                        Url = slug,
                        Description = s.Description,
                        Position = s.Position,
                        CreatedDate = (from sl in context.TblSliders where sl.Id == id select sl.CreatedDate).FirstOrDefault(),
                        CreatedBy = (from sl in context.TblSliders where sl.Id == id select sl.CreatedBy).FirstOrDefault(),
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = s.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = s.IsActive,
                    };
                    string oldName = (from sl in context.TblSliders where sl.Id == id select sl.Image).FirstOrDefault();
                    if (s.FileImage != null)
                    {
                        String fileName = slug + s.FileImage.FileName.Substring(s.FileImage.FileName.LastIndexOf('.'));
                        if(fileName != oldName && oldName != null && File.Exists(route + oldName))
                        {
                            File.Delete(route + oldName);
                        }
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            s.FileImage.CopyTo(stream);
                        }
                        slider.Image = fileName;
                    }
                    else
                    {
                        string[] newNameImage = oldName.Split(".");
                        string newName = slug + "." + newNameImage[newNameImage.Length - 1];
                        if(newName != oldName && File.Exists(route + oldName))
                        {
                            File.Move(route + oldName, route + newName);
                            slider.Image = newName;
                        }
                        else
                        {
                            slider.Image = oldName;
                        }
                    }
                    context.Entry(slider).State = EntityState.Modified;
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
                    TblSlider slider = context.TblSliders.Find(id);
                    slider.IsDelete = 1;

                    slider.UpdatedDate = DateTime.Now;
                    slider.UpdatedBy = updatedBy;

                    context.Entry(slider).State = EntityState.Modified;
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
                    TblSlider slider = context.TblSliders.Find(id);
                    slider.IsDelete = 0;

                    slider.UpdatedDate = DateTime.Now;
                    slider.UpdatedBy = updatedBy;

                    context.Entry(slider).State = EntityState.Modified;
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
                    TblSlider slider = context.TblSliders.Find(id);
                    slider.IsActive = (byte?)((slider.IsActive == 1) ? 0 : 1);
                    slider.UpdatedDate = DateTime.Now;
                    slider.UpdatedBy = updatedBy;
                    context.Entry(slider).State = EntityState.Modified;
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
