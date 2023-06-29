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
    public interface INewsCategoryService
    {
        List<TblNewsCategory> GetAllNewsCategory(int isDelete);

        List<TblNewsCategory> GetAllNewsCategory(int page, int take, int isDelete);

        NewsCategoryEntity GetNewsCategoryById(long id);

        List<TblNewsCategory> GetNewsCategoriesByName(string name, int isDelete);

        List<TblNewsCategory> GetNewsCategoriesByName(string name, int page, int take, int isDelete);

        int AddNewsCategory(NewsCategoryImage newCategory);

        int EditNewsCategory(long id, NewsCategoryImage newCategory);

        int DeleteNewsCategory(long id);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);

        int ChangeActive(long id, long updatedBy);
    }
}
