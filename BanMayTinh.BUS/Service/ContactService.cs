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
    public class ContactService : IContactService
    {
        public int CreateContact(TblContact contact) => ContactDAO.Create(contact);

        public int DeleteContact(long id) => ContactDAO.Delete(id);

        public int DelTrash(long id, long updatedBy) => ContactDAO.DelTrash(id, updatedBy);

        public List<TblContact> GetAllContact(int isDelete) => ContactDAO.GetAll(isDelete);

        public List<TblContact> GetAllContact(int page, int take, int isDelete) => ContactDAO.GetAll(page, take, isDelete);

        public ContactEntity GetContactById(long id) => ContactDAO.GetById(id);

        public List<TblContact> GetContactsByEmail(string email, int isDelete) => ContactDAO.GetByEmail(email, isDelete);

        public List<TblContact> GetContactsByEmail(string email, int page, int take, int isDelete) => ContactDAO.GetByEmail(email, page, take, isDelete);

        public int ReplyContact(long id, TblContact contact) => ContactDAO.Reply(id, contact);

        public int ReTrash(long id, long updatedBy) => ContactDAO.ReTrash(id, updatedBy);
    }
}
