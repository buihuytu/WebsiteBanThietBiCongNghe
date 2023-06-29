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
    public class ProductService : IProductService
    {
        public int ChangeActive(long id, long updatedBy) => ProductDAO.ChangeActive(id, updatedBy);

        public int ChangeDiscount(long id, long updatedBy) => ProductDAO.ChangeDiscount(id, updatedBy);

        public int ChangeHotProduct(long id, long updatedBy) => ProductDAO.ChangeHotProduct(id, updatedBy);

        public int CreateProduct(ProductImage product) => ProductDAO.Create(product);

        public int DeleteProduct(long id) => ProductDAO.Delete(id);

        public int DelTrash(long id, long updatedBy) => ProductDAO.DelTrash(id, updatedBy);

        public List<ProductEntity> GetAllProducts(int isDelete) => ProductDAO.GetAll(isDelete);

        public List<ProductEntity> GetAllProducts(int page, int take, int isDelete) => ProductDAO.GetAll(page, take, isDelete);

        public long GetIdByName(string name) => ProductDAO.GetIdByName(name);

        public ProductEntity GetProductById(long id) => ProductDAO.GetById(id);

        public List<ProductEntity> GetProductByName(string name, int isDelete) => ProductDAO.GetByName(name, isDelete);

        public List<ProductEntity> GetProductByName(string name, int page, int take, int isDelete) => ProductDAO.GetByName(name, page, take, isDelete);

        public int ReTrash(long id, long updatedBy) => ProductDAO.ReTrash(id, updatedBy);

        public int UpdateProduct(long id, ProductImage product) => ProductDAO.Update(id, product);
    }
}
