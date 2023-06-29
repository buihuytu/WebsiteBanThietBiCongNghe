using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.DTO;
using BanMayTinh.UTILITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BanMayTinh.DAO
{
    public class OrderDAO
    {
        public static List<TblOrder> getAll(int isDelete)
        {
            List<TblOrder> list = new List<TblOrder>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblOrders.Where(c => c.IsDelete == isDelete).ToList();
            }
            return list;
        }

        public static List<TblOrder> getAll(int page, int take, int isDelete)
        {
            List<TblOrder> list = new List<TblOrder>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblOrders.Where(c => c.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static OrderEntity getOrderById(long id)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var order = (from o in context.TblOrders
                                 where o.Id == id
                                 select new OrderEntity()
                                 {
                                     Id = o.Id,
                                     Code = o.Code,
                                     ReceiverName = o.ReceiverName,
                                     ReceiverPhone = o.ReceiverPhone,
                                     ReceiverEmail = o.ReceiverEmail,
                                     ReceiverAddress = o.ReceiverAddress,
                                     CreatedDate = o.CreatedDate,
                                     UpdatedName = (o.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == o.UpdatedBy select a.Name).FirstOrDefault()),
                                     ExportedDate = o.ExportedDate,
                                     UpdatedDate = o.UpdatedDate,
                                     Notes = o.Notes,
                                     Status = o.Status,
                                 }).FirstOrDefault();
                    return order;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<TblOrder> getOrderByName(string name, int isDelete)
        {
            List<TblOrder> list = new List<TblOrder> ();
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    list = context.TblOrders.Where(o => o.ReceiverName.Contains(name) && o.IsDelete == isDelete).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<TblOrder> getOrderByName(string name, int page, int take, int isDelete)
        {
            List<TblOrder> list = new List<TblOrder>();
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    list = context.TblOrders.Where(o => o.ReceiverName.Contains(name) && o.IsDelete == isDelete).Skip((page - 1) * take).Take(take).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int deleteOrder(long id)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var order = context.TblOrders.SingleOrDefault(c => c.Id == id);
                    if (order != null)
                    {
                        var orderDetails = context.TblOrderDetails.Where(od => od.OrderId == id).ToList();
                        foreach(var od in orderDetails)
                        {
                            context.TblOrderDetails.Remove(od);
                            context.SaveChanges();
                        }
                        context.TblOrders.Remove(order);
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

        public static int DelTrash(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblOrder order = context.TblOrders.Find(id);
                    order.IsDelete = 1;

                    order.UpdatedDate = DateTime.Now;
                    order.UpdatedBy = updatedBy;

                    context.Entry(order).State = EntityState.Modified;
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
                    TblOrder order = context.TblOrders.Find(id);
                    order.IsDelete = 0;

                    order.UpdatedDate = DateTime.Now;
                    order.UpdatedBy = updatedBy;

                    context.Entry(order).State = EntityState.Modified;
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

        public static int ChangeStatus(long id, long updatedBy, int status)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblOrder order = context.TblOrders.Find(id);
                    order.Status = (byte?)status;
                    order.UpdatedDate = DateTime.Now;
                    order.UpdatedBy = updatedBy;
                    if (status == (int)OrderStatus.Delivery || status == (int)OrderStatus.Completed)
                    {
                        order.ExportedDate = DateTime.Now;
                    }
                    else
                    {
                        order.ExportedDate = null;
                    }

                    context.Entry(order).State = EntityState.Modified;
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
