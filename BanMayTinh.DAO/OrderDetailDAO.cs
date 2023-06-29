using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DAO
{
    public class OrderDetailDAO
    {
        public static List<OrderDetailEntity> getAllOrderDetails(long orderId)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var listDetails = (from o in context.TblOrderDetails
                                 where o.OrderId == orderId
                                 select new OrderDetailEntity()
                                 {
                                     Id = o.Id,
                                     OrderId = orderId, 
                                     ProductId = o.ProductId,
                                     ProductName = (from p in context.TblProducts where p.Id == o.ProductId select p.Name).FirstOrDefault(),
                                     ProductImage = (from p in context.TblProducts where p.Id == o.ProductId select p.Image).FirstOrDefault(),
                                     Price = o.Price,
                                     Quantity = o.Quantity,
                                     Total = o.Total,
                                 }).ToList();
                    return listDetails;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
