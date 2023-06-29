using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.UTILITIES.Enums;
using BanMayTinh.UTILITIES.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DAO
{
    public class AccountDAO
    {
        public static List<AccountEntity> GetAll(int isDelete)
        {
            var list = new List<AccountEntity>();
            using (var context = new WebbanmaytinhContext())
            {
                list = (from a in context.TblAccounts
                        where a.IsDelete == isDelete
                        select new AccountEntity()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Avatar = a.Avatar,
                            Username = a.Username,
                            Password = a.Password,
                            RoleId = a.IdRole,
                            RoleName = (from r in context.TblRoles where a.IdRole == r.Id select r.Name).FirstOrDefault(),
                            Address = a.Address == null ? "" : a.Address,
                            Email = a.Email == null ? "" : a.Email,
                            Phone = a.Phone == null ? "" : a.Phone,
                            CreatedDate = a.CreatedDate,
                            CreatedName = (from ac in context.TblAccounts where ac.Id == a.CreatedBy select ac.Username).FirstOrDefault(),
                            UpdatedDate = a.UpdatedDate,
                            UpdatedName = (from ac in context.TblAccounts where ac.Id == a.UpdatedBy select ac.Username).FirstOrDefault(),
                            IsDelete = (int)DeleteStatus.IsNotDelete,
                            IsActive = a.IsActive,
                        }).ToList();
            }
            return list;
        }

        public static List<AccountEntity> GetAll(int page, int take, int isDelete)
        {
            var list = new List<AccountEntity>();
            using (var context = new WebbanmaytinhContext())
            {
                list = (from a in context.TblAccounts
                        where a.IsDelete == isDelete
                        select new AccountEntity()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Avatar = a.Avatar,
                            Username = a.Username,
                            Password = a.Password,
                            RoleId = a.IdRole,
                            RoleName = (from r in context.TblRoles where a.IdRole == r.Id select r.Name).FirstOrDefault(),
                            Address = a.Address == null ? "" : a.Address,
                            Email = a.Email == null ? "" : a.Email,
                            Phone = a.Phone == null ? "" : a.Phone,
                            CreatedDate = a.CreatedDate,
                            CreatedName = (from ac in context.TblAccounts where ac.Id == a.CreatedBy select ac.Username).FirstOrDefault(),
                            UpdatedDate = a.UpdatedDate,
                            UpdatedName = (from ac in context.TblAccounts where ac.Id == a.UpdatedBy select ac.Username).FirstOrDefault(),
                            IsDelete = (int)DeleteStatus.IsNotDelete,
                            IsActive = a.IsActive,
                        }).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static AccountEntity GetById(long id)
        {
            try
            {
                var account = new AccountEntity();
                using (var context = new WebbanmaytinhContext())
                {
                    account = (from a in context.TblAccounts
                               where a.Id == id
                               select new AccountEntity()
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Avatar = a.Avatar,
                                   Username = a.Username,
                                   Password = a.Password,
                                   RoleId = a.IdRole,
                                   RoleName = (from r in context.TblRoles where a.IdRole == r.Id select r.Name).FirstOrDefault(),
                                   Address = a.Address == null ? "" : a.Address,
                                   Email = a.Email == null ? "" : a.Email,
                                   Phone = a.Phone == null ? "" : a.Phone,
                                   CreatedDate = a.CreatedDate,
                                   CreatedName = (from ac in context.TblAccounts where ac.Id == a.CreatedBy select ac.Username).FirstOrDefault(),
                                   UpdatedDate = a.UpdatedDate,
                                   UpdatedName = (from ac in context.TblAccounts where ac.Id == a.UpdatedBy select ac.Username).FirstOrDefault(),
                                   IsDelete = (int)DeleteStatus.IsNotDelete,
                                   IsActive = a.IsActive,
                               }).FirstOrDefault();
                }
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<AccountEntity> GetByUserName(string username, int isDelete)
        {
            try
            {
                var account = new List<AccountEntity>();
                using (var context = new WebbanmaytinhContext())
                {
                    account = (from a in context.TblAccounts
                               where a.Name.Contains(username) && a.IsDelete == isDelete
                               select new AccountEntity()
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Avatar = a.Avatar,
                                   Username = a.Username,
                                   Password = a.Password,
                                   RoleId = a.IdRole,
                                   RoleName = (from r in context.TblRoles where a.IdRole == r.Id select r.Name).FirstOrDefault(),
                                   Address = a.Address == null ? "" : a.Address,
                                   Email = a.Email == null ? "" : a.Email,
                                   Phone = a.Phone == null ? "" : a.Phone,
                                   CreatedDate = a.CreatedDate,
                                   CreatedName = (from ac in context.TblAccounts where ac.Id == a.CreatedBy select ac.Username).FirstOrDefault(),
                                   UpdatedDate = a.UpdatedDate,
                                   UpdatedName = (from ac in context.TblAccounts where ac.Id == a.UpdatedBy select ac.Username).FirstOrDefault(),
                                   IsDelete = (int)DeleteStatus.IsNotDelete,
                                   IsActive = a.IsActive,
                               }).ToList();
                }
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<AccountEntity> GetByUserName(string username, int page, int take, int isDelete)
        {
            try
            {
                var account = new List<AccountEntity>();
                using (var context = new WebbanmaytinhContext())
                {
                    account = (from a in context.TblAccounts
                               where a.Name.Contains(username) && a.IsDelete == isDelete
                               select new AccountEntity()
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Avatar = a.Avatar,
                                   Username = a.Username,
                                   Password = a.Password,
                                   RoleId = a.IdRole,
                                   RoleName = (from r in context.TblRoles where a.IdRole == r.Id select r.Name).FirstOrDefault(),
                                   Address = a.Address == null ? "" : a.Address,
                                   Email = a.Email == null ? "" : a.Email,
                                   Phone = a.Phone == null ? "" : a.Phone,
                                   CreatedDate = a.CreatedDate,
                                   CreatedName = (from ac in context.TblAccounts where ac.Id == a.CreatedBy select ac.Username).FirstOrDefault(),
                                   UpdatedDate = a.UpdatedDate,
                                   UpdatedName = (from ac in context.TblAccounts where ac.Id == a.UpdatedBy select ac.Username).FirstOrDefault(),
                                   IsDelete = (int)DeleteStatus.IsNotDelete,
                                   IsActive = a.IsActive,
                               }).Skip((page - 1) * take).Take(take).ToList();
                }
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<AccountEntity> GetByRole(long roleId)
        {
            try
            {
                var list = new List<AccountEntity>();
                using (var context = new WebbanmaytinhContext())
                {
                    list = (from a in context.TblAccounts
                            join r in context.TblRoles
                            on a.IdRole equals r.Id
                            where a.IdRole == roleId
                            select new AccountEntity()
                            {
                                Id = a.Id,
                                Name = a.Name,
                                Avatar = a.Avatar,
                                Username = a.Username,
                                Password = a.Password,
                                RoleId = a.IdRole,
                                RoleName = (from r in context.TblRoles where a.IdRole == r.Id select r.Name).FirstOrDefault(),
                                Address = a.Address == null ? "" : a.Address,
                                Email = a.Email == null ? "" : a.Email,
                                Phone = a.Phone == null ? "" : a.Phone,
                                CreatedDate = a.CreatedDate,
                                CreatedName = (from ac in context.TblAccounts where ac.Id == a.CreatedBy select ac.Username).FirstOrDefault(),
                                UpdatedDate = a.UpdatedDate,
                                UpdatedName = (from ac in context.TblAccounts where ac.Id == a.UpdatedBy select ac.Username).FirstOrDefault(),
                                IsDelete = (int)DeleteStatus.IsNotDelete,
                                IsActive = a.IsActive,
                            }).ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int Create(AccountImage a)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Avatar\\";
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblAccount", a.Username, null))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    var account = new TblAccount
                    {
                        Name = a.Name,
                        Username = a.Username,
                        Password = a.Password,
                        IdRole = a.IdRole,
                        Address = a.Address,
                        Email = a.Email,
                        Phone = a.Phone,
                        CreatedDate = DateTime.Now,
                        CreatedBy = a.CreatedBy,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = a.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = a.IsActive,
                    };
                    if (a.FileImage != null)
                    {
                        String fileName = a.Username + a.FileImage.FileName.Substring(a.FileImage.FileName.LastIndexOf('.'));
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            a.FileImage.CopyTo(stream);
                        }
                        account.Avatar = fileName;
                    }
                    else
                    {
                        account.Avatar = null;
                    }
                    context.TblAccounts.Add(account);
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch(Exception ex)
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
                    var account = context.TblAccounts.SingleOrDefault(r => r.Id == id);
                    if (account != null)
                    {
                        context.TblAccounts.Remove(account);
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

        public static int Update(long id, AccountImage a)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Avatar\\";
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblAccount", a.Username, id))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    var account = new TblAccount
                    {
                        Id = id,
                        Name = a.Name,
                        Username = a.Username,
                        Password = a.Password,
                        IdRole = a.IdRole,
                        Address = a.Address,
                        Email = a.Email,
                        Phone = a.Phone,
                        CreatedDate = (from acc in context.TblAccounts where acc.Id == id select acc.CreatedDate).FirstOrDefault(),
                        CreatedBy = (from acc in context.TblAccounts where acc.Id == id select acc.CreatedBy).FirstOrDefault(),
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = a.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = a.IsActive,
                    };
                    string oldName = (from acc in context.TblAccounts where acc.Id == id select acc.Avatar).FirstOrDefault();
                    if (a.FileImage != null)
                    {
                        String fileName = a.Username + a.FileImage.FileName.Substring(a.FileImage.FileName.LastIndexOf('.'));
                        if (fileName != oldName && oldName != null && File.Exists(route + oldName))
                        {
                            File.Delete(route + oldName);
                        }
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            a.FileImage.CopyTo(stream);
                        }
                        account.Avatar = fileName;
                    }
                    else
                    {
                        string[] newNameImage = oldName.Split(".");
                        string newName = a.Username + "." + newNameImage[newNameImage.Length - 1];
                        if (newName != oldName && File.Exists(route + oldName))
                        {
                            File.Move(route + oldName, route + newName);
                            account.Avatar = newName;
                        }
                        else
                        {
                            account.Avatar = oldName;
                        }
                    }
                    context.Entry(account).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch(Exception ex)
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
                    TblAccount account = context.TblAccounts.Find(id);
                    account.IsDelete = 1;

                    account.UpdatedDate = DateTime.Now;
                    account.UpdatedBy = updatedBy;

                    context.Entry(account).State = EntityState.Modified;
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
                    TblAccount account = context.TblAccounts.Find(id);
                    account.IsDelete = 0;

                    account.UpdatedDate = DateTime.Now;
                    account.UpdatedBy = updatedBy;

                    context.Entry(account).State = EntityState.Modified;
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
                    TblAccount account = context.TblAccounts.Find(id);
                    account.IsActive = (byte?)((account.IsActive == 1) ? 0 : 1);
                    account.UpdatedDate = DateTime.Now;
                    account.UpdatedBy = updatedBy;
                    context.Entry(account).State = EntityState.Modified;
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
