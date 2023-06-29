using BanMayTinh.BUS.IService;
using BanMayTinh.DAO;
using BanMayTinh.DTO.DTO.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.BUS.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        public List<OrderDetailEntity> GetAllOrderDetail(long orderId) => OrderDetailDAO.getAllOrderDetails(orderId);

    }
}
