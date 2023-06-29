using BanMayTinh.BUS.IService;
using BanMayTinh.DAO;
using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.BUS.Service
{
    public class AccountService : IAccountService
    {
        public int AddAccount(AccountImage account) => AccountDAO.Create(account);

        public int DeleteAccount(long id) => AccountDAO.Delete(id);

        public AccountEntity GetAccountById(long id) => AccountDAO.GetById(id);

        public List<AccountEntity> GetAccountByUserName(string name, int page, int take, int isDelete) => AccountDAO.GetByUserName(name, page, take, isDelete);

        public List<AccountEntity> GetAccountByRole(long roleId) => AccountDAO.GetByRole(roleId);

        public List<AccountEntity> GetAllAccounts(int isDelete) => AccountDAO.GetAll(isDelete);

        public int UpdateAccount(long id, AccountImage account) => AccountDAO.Update(id, account);

        public int DelTrash(long id, long updatedBy) => AccountDAO.DelTrash(id, updatedBy);

        public int ReTrash(long id, long updatedBy) => AccountDAO.ReTrash(id, updatedBy);

        public int ChangeActive(long id, long updatedBy) => AccountDAO.ChangeActive(id, updatedBy);

        public List<AccountEntity> GetAllAccounts(int page, int take, int isDelete) => AccountDAO.GetAll(page, take, isDelete);

        public List<AccountEntity> GetAccountByUserName(string name, int isDelete) => AccountDAO.GetByUserName(name, isDelete);
    }
}
