using BanMayTinh.BUS.IService;
using BanMayTinh.DAO;
using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.BUS.Service
{
    public class OrderService : IOrderService
    {
        public int ChangeStatus(long id, long updatedBy, int status) => OrderDAO.ChangeStatus(id, updatedBy, status);

        public int DeleteOrder(long id) => OrderDAO.deleteOrder(id);

        public int DelTrash(long id, long updatedBy) => OrderDAO.DelTrash(id, updatedBy);

        public List<TblOrder> GetAllOrders(int isDelete) => OrderDAO.getAll(isDelete);

        public List<TblOrder> GetAllOrders(int page, int take, int isDelete) => OrderDAO.getAll(page, take, isDelete);

        public OrderEntity GetOrderById(long id) => OrderDAO.getOrderById(id);

        public List<TblOrder> GetOrdersByName(string name, int isDelete) => OrderDAO.getOrderByName(name, isDelete);

        public List<TblOrder> GetOrdersByName(string name, int page, int take, int isDelete) => OrderDAO.getOrderByName(name, page, take, isDelete);

        public int ReTrash(long id, long updatedBy) => OrderDAO.ReTrash(id, updatedBy);
    }
}
