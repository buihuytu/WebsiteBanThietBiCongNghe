using BanMayTinh.DTO;
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
    public class ContactDAO
    {
        public static List<TblContact> GetAll(int isDelete)
        {
            var list = new List<TblContact>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblContacts.Where(c => c.IsDelete == isDelete).ToList();
            }
            return list;
        }

        public static List<TblContact> GetAll(int page, int take, int isDelete)
        {
            var list = new List<TblContact>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblContacts.Where(c => c.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static ContactEntity GetById(long id)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var contact = new ContactEntity();
                    var ct = context.TblContacts.FirstOrDefault(c => c.Id == id);
                    contact = (from c in context.TblContacts
                                where c.Id == id
                                select new ContactEntity()
                                {
                                    Id = c.Id,
                                    FullName = c.FullName,
                                    Email = c.Email,
                                    Phone = c.Phone,
                                    Enquiry = c.Enquiry,
                                    Reply = c.Reply == null ? "" : c.Reply,
                                    CreatedDate = c.CreatedDate,
                                    RepliedBy = (c.RepliedBy == null ? "" : (from a in context.TblAccounts where a.Id == c.RepliedBy select a.Username).FirstOrDefault()),
                                    RepliedDate = c.RepliedDate,
                                    IsDelete = c.IsDelete,
                                    IsReply = c.IsReply,
                                }).FirstOrDefault();
                    
                    return contact;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<TblContact> GetByEmail(string email, int isDelete)
        {
            var list = new List<TblContact>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblContacts.Where(c => c.Email.Contains(email) && c.IsDelete == isDelete).ToList();
            }
            return list;
        }

        public static List<TblContact> GetByEmail(string email, int page, int take, int isDelete)
        {
            var list = new List<TblContact>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblContacts.Where(c => c.Email.Contains(email) && c.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static int Create(TblContact contact)
        {
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    contact.CreatedDate = DateTime.Now;
                    contact.IsReply = 0;
                    contact.IsDelete = 0;

                    context.TblContacts.Add(contact);
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
                    var contact = context.TblContacts.SingleOrDefault(c => c.Id == id);
                    if (contact != null)
                    {
                        context.TblContacts.Remove(contact);
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

        public static int Reply(long id, TblContact contact)
        {
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    contact.FullName = (from c in context.TblContacts where c.Id == id select c.FullName).FirstOrDefault();
                    contact.Email = (from c in context.TblContacts where c.Id == id select c.Email).FirstOrDefault();
                    contact.Phone = (from c in context.TblContacts where c.Id == id select c.Phone).FirstOrDefault();
                    contact.Enquiry = (from c in context.TblContacts where c.Id == id select c.Enquiry).FirstOrDefault();
                    contact.CreatedDate = (from c in context.TblContacts where c.Id == id select c.CreatedDate).FirstOrDefault();
                    contact.IsDelete = (int)DeleteStatus.IsNotDelete;
                    contact.IsReply = 1;
                    contact.RepliedDate = DateTime.Now;

                    context.Entry(contact).State = EntityState.Modified;
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
                    TblContact contact = context.TblContacts.Find(id);
                    contact.IsDelete = 1;

                    context.Entry(contact).State = EntityState.Modified;
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
                    TblContact contact = context.TblContacts.Find(id);
                    contact.IsDelete = 0;

                    context.Entry(contact).State = EntityState.Modified;
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
