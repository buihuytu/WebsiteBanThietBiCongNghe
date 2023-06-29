using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.UTILITIES.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DAO
{
    public class RoleDAO
    {
        public static List<TblRole> getAll(int isDelete)
        {
            var list = new List<TblRole>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblRoles.Where(r => r.IsDelete == isDelete).ToList();
            }
            return list;
        }

        public static List<TblRole> getAll(int page, int take, int isDelete)
        {
            var list = new List<TblRole>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblRoles.Where(r => r.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static RoleEntity getById(long id)
        {
            try
            {
                var role = new RoleEntity();
                using (var context = new WebbanmaytinhContext())
                {
                    role = (from r in context.TblRoles
                            where r.Id == id
                            select new RoleEntity()
                            {
                                Id = r.Id,
                                Name = r.Name,
                                CreatedDate = r.CreatedDate,
                                CreatedName = r.CreatedBy == null ? "" : (from a in context.TblAccounts where r.CreatedBy == a.Id select a.Username).FirstOrDefault(),
                                UpdatedDate = r.UpdatedDate,
                                UpdatedName = r.UpdatedBy == null ? "" : (from a in context.TblAccounts where r.UpdatedBy == a.Id select a.Username).FirstOrDefault(),
                                IsDelete = r.IsDelete,
                                IsActive = r.IsActive,
                            }).FirstOrDefault();
                }
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<TblRole> getByName(string name, int isDelete)
        {
            try
            {
                var list = new List<TblRole>();
                using (var context = new WebbanmaytinhContext())
                {
                    list = context.TblRoles.Where(r => r.Name.Contains(name) && r.IsDelete == isDelete).ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<TblRole> getByName(string name, int page, int take, int isDelete)
        {
            try
            {
                var list = new List<TblRole>();
                using (var context = new WebbanmaytinhContext())
                {
                    list = context.TblRoles.Where(r => r.Name.Contains(name) && r.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int Create(TblRole role)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    int checkExists = context.TblRoles.Where(r => r.Name == role.Name).Count();
                    if(checkExists != 0)
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    role.CreatedDate = DateTime.Now;
                    role.UpdatedDate = DateTime.Now;
                    role.IsDelete = (byte?)DeleteStatus.IsNotDelete;

                    context.TblRoles.Add(role);
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
                    var role = context.TblRoles.SingleOrDefault(r => r.Id == id);
                    if (role != null)
                    {
                        context.TblRoles.Remove(role);
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

        public static int Edit(long id, TblRole role)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    int checkExists = context.TblRoles.Where(r => r.Name == role.Name).Count();
                    if (checkExists != 0)
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    role.CreatedDate = (from r in context.TblRoles where r.Id == id select r.CreatedDate).FirstOrDefault();
                    role.CreatedBy = (from r in context.TblRoles where r.Id == id select r.CreatedBy).FirstOrDefault();
                    role.UpdatedDate = DateTime.Now;
                    role.IsDelete = (byte?)DeleteStatus.IsNotDelete;

                    context.Entry(role).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
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
                    TblRole role = context.TblRoles.Find(id);
                    role.IsDelete = 1;

                    role.UpdatedDate = DateTime.Now;
                    role.UpdatedBy = updatedBy;

                    context.Entry(role).State = EntityState.Modified;
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
                    TblRole role = context.TblRoles.Find(id);
                    role.IsDelete = 0;

                    role.UpdatedDate = DateTime.Now;
                    role.UpdatedBy = updatedBy;

                    context.Entry(role).State = EntityState.Modified;
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
                    TblRole role = context.TblRoles.Find(id);
                    role.IsActive = (byte?)((role.IsActive == 1) ? 0 : 1);
                    role.UpdatedDate = DateTime.Now;
                    role.UpdatedBy = updatedBy;
                    context.Entry(role).State = EntityState.Modified;
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
