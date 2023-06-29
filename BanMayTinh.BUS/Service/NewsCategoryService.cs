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
    public class NewsCategoryService : INewsCategoryService
    {
        public int AddNewsCategory(NewsCategoryImage newCategory) => NewsCategoryDAO.Create(newCategory);

        public int ChangeActive(long id, long updatedBy) => NewsCategoryDAO.ChangeActive(id, updatedBy);

        public int DeleteNewsCategory(long id) => NewsCategoryDAO.Delete(id);

        public int DelTrash(long id, long updatedBy) => NewsCategoryDAO.DelTrash(id, updatedBy);

        public int EditNewsCategory(long id, NewsCategoryImage newCategory) => NewsCategoryDAO.Update(id, newCategory);

        public List<TblNewsCategory> GetAllNewsCategory(int isDelete) => NewsCategoryDAO.getAll(isDelete);

        public List<TblNewsCategory> GetAllNewsCategory(int page, int take, int isDelete) => NewsCategoryDAO.getAll(page, take, isDelete);

        public List<TblNewsCategory> GetNewsCategoriesByName(string name, int isDelete) => NewsCategoryDAO.getByName(name, isDelete);

        public List<TblNewsCategory> GetNewsCategoriesByName(string name, int page, int take, int isDelete) => NewsCategoryDAO.getByName(name, page, take, isDelete);

        public NewsCategoryEntity GetNewsCategoryById(long id) => NewsCategoryDAO.getById(id);

        public int ReTrash(long id, long updatedBy) => NewsCategoryDAO.ReTrash(id, updatedBy);
    }
}
