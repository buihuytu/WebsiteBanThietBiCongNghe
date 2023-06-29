using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.BUS.IService
{
    public interface IAccountService
    {
        List<AccountEntity> GetAllAccounts(int isDelete);

        List<AccountEntity> GetAllAccounts(int page, int take, int isDelete);

        AccountEntity GetAccountById(long id);

        List<AccountEntity> GetAccountByUserName(string name, int isDelete);

        List<AccountEntity> GetAccountByUserName(string name, int page, int take, int isDelete);

        List<AccountEntity> GetAccountByRole(long roleId);

        int AddAccount(AccountImage account);

        int UpdateAccount(long id, AccountImage account);

        int DeleteAccount(long id);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);

        int ChangeActive(long id, long updatedBy);
    }
}
