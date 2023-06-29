using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;

namespace BanMayTinh.BUS.IService
{
    public interface ICategoryService
    {
        List<TblCategory> GetAllCategories(int isDelete);

        List<TblCategory> GetAllCategories(int page, int take, int isDelete);

        CategoryEntity GetCategoryById(long id);

        List<TblCategory> GetCategoryByName(string name, int isDelete);

        List<TblCategory> GetCategoryByName(string name, int page, int take, int isDelete);

        int AddCategory(CategoryImage category);

        int EditCategory(long id, CategoryImage category);
        
        int DeleteCategory(long id);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);

        int ChangeActive(long id, long updatedBy);

    }
}
