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
    public class RoleService : IRoleService
    {
        public int AddRole(TblRole role) => RoleDAO.Create(role);

        public int ChangeActive(long id, long updatedBy) => RoleDAO.ChangeActive(id, updatedBy);

        public int DeleteRole(long id) => RoleDAO.Delete(id);

        public int DelTrash(long id, long updatedBy) => RoleDAO.DelTrash(id, updatedBy);

        public int EditRole(long id, TblRole role) => RoleDAO.Edit(id, role);

        public List<TblRole> GetAllRoles(int isDelete) => RoleDAO.getAll(isDelete);

        public List<TblRole> GetAllRoles(int page, int take, int isDelete) => RoleDAO.getAll(page, take, isDelete);

        public RoleEntity GetRoleById(long id) => RoleDAO.getById(id);

        public List<TblRole> GetRolesByName(string name, int isDelete) => RoleDAO.getByName(name, isDelete);

        public List<TblRole> GetRolesByName(string name, int page, int take, int isDelete) => RoleDAO.getByName(name, page, take, isDelete);

        public int ReTrash(long id, long updatedBy) => RoleDAO.ReTrash(id, updatedBy);
    }
}
