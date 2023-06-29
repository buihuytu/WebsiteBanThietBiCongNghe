using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.BUS.IService
{
    public interface IContactService
    {
        List<TblContact> GetAllContact(int isDelete);

        List<TblContact> GetAllContact(int page, int take, int isDelete);

        ContactEntity GetContactById(long id);

        List<TblContact> GetContactsByEmail(string email, int isDelete);

        List<TblContact> GetContactsByEmail(string email, int page, int take, int isDelete);

        int CreateContact(TblContact contact);

        int ReplyContact(long id, TblContact contact);

        int DeleteContact(long id);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);
    }
}
