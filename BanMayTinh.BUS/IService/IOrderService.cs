using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.BUS.IService
{
    public interface IOrderService
    {
        List<TblOrder> GetAllOrders(int isDelete);

        List<TblOrder> GetAllOrders(int page, int take, int isDelete);

        OrderEntity GetOrderById(long id);

        List<TblOrder> GetOrdersByName(string name, int isDelete);

        List<TblOrder> GetOrdersByName(string name, int page, int take, int isDelete);

        int DeleteOrder(long id);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);

        int ChangeStatus(long id, long updatedBy, int status);
    }
}
