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
    public interface IBrandService
    {
        List<BrandEntity> GetAllBrands(int isDelete);

        List<BrandEntity> GetAllBrands(int page, int take, int isDelete);

        BrandEntity GetBrandById(long id);

        List<BrandEntity> GetBrandByName(string name, int isDelete);

        List<BrandEntity> GetBrandByName(string name, int page, int take, int isDelete);

        int CreateBrand(BrandImage brand);

        int UpdateBrand(long id, BrandImage brand);

        int DeleteBrand(long id);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);

        int ChangeActive(long id, long updatedBy);


    }
}
