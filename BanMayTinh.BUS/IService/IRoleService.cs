using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.BUS.IService
{
    public interface IRoleService
    {
        List<TblRole> GetAllRoles(int isDelete);

        List<TblRole> GetAllRoles(int page, int take, int isDelete);

        RoleEntity GetRoleById(long id);

        List<TblRole> GetRolesByName(string name, int isDelete);

        List<TblRole> GetRolesByName(string name, int page, int take, int isDelete);

        int AddRole(TblRole role);

        int EditRole(long id, TblRole role);

        int DeleteRole(long id);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);

        int ChangeActive(long id, long updatedBy);

    }
}
