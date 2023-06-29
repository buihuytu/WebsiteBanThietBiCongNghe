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
    public interface IProductService
    {
        List<ProductEntity> GetAllProducts(int isDelete);

        List<ProductEntity> GetAllProducts(int page, int take, int isDelete);

        ProductEntity GetProductById(long id);

        List<ProductEntity> GetProductByName(string name, int isDelete);

        List<ProductEntity> GetProductByName(string name, int page, int take, int isDelete);

        int CreateProduct(ProductImage product);

        int DeleteProduct(long id);

        int UpdateProduct(long id, ProductImage product);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);

        int ChangeActive(long id, long updatedBy);

        int ChangeDiscount(long id, long updatedBy);
        
        int ChangeHotProduct(long id, long updatedBy);

        long GetIdByName(string name);
    }
}
