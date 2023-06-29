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
    public class CategoryService : ICategoryService
    {
        public int AddCategory(CategoryImage category) => CategoryDAO.AddCategory(category);

        public int ChangeActive(long id, long updatedBy) => CategoryDAO.ChangeActive(id, updatedBy);

        public int DeleteCategory(long id) => CategoryDAO.DeleteCategory(id);

        public int DelTrash(long id, long updatedBy) => CategoryDAO.DelTrash(id, updatedBy);

        public int EditCategory(long id, CategoryImage category) => CategoryDAO.EditCategory(id, category);

        public List<TblCategory> GetAllCategories(int isDelete) => CategoryDAO.getAll(isDelete);

        public List<TblCategory> GetAllCategories(int page, int take, int isDelete) => CategoryDAO.getAll(page, take, isDelete);

        public CategoryEntity GetCategoryById(long id) => CategoryDAO.getCategoryById(id);

        public List<TblCategory> GetCategoryByName(string name, int isDelete) => CategoryDAO.getCategoryByName(name, isDelete);

        public List<TblCategory> GetCategoryByName(string name, int page, int take, int isDelete) => CategoryDAO.getCategoryByName(name, page, take, isDelete);

        public int ReTrash(long id, long updatedBy) => CategoryDAO.ReTrash(id, updatedBy);
    }
}
