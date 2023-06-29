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
    public class BrandService : IBrandService
    {
        public int ChangeActive(long id, long updatedBy) => BrandDAO.ChangeActive(id, updatedBy);

        public int CreateBrand(BrandImage brand) => BrandDAO.Create(brand);

        public int DeleteBrand(long id) => BrandDAO.Delete(id);

        public int DelTrash(long id, long updatedBy) => BrandDAO.DelTrash(id, updatedBy);

        public List<BrandEntity> GetAllBrands(int isDelete) => BrandDAO.GetAll(isDelete);

        public List<BrandEntity> GetAllBrands(int page, int take, int isDelete) => BrandDAO.GetAll(page, take, isDelete);

        public BrandEntity GetBrandById(long id) => BrandDAO.GetById(id);

        public List<BrandEntity> GetBrandByName(string name, int isDelete) => BrandDAO.GetBrandByName(name, isDelete);

        public List<BrandEntity> GetBrandByName(string name, int page, int take, int isDelete) => BrandDAO.GetBrandByName(name, page, take, isDelete);

        public int ReTrash(long id, long updatedBy) => BrandDAO.ReTrash(id, updatedBy);

        public int UpdateBrand(long id, BrandImage brand) => BrandDAO.Update(id, brand);
    }
}
