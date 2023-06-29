using BanMayTinh.BUS.IService;
using BanMayTinh.DAO;
using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.BUS.Service
{
    public class ProductImageService : IProductImageService
    {
        public int CreateListImages(ImgProduct imgProduct) => ProductImageDAO.CreateList(imgProduct);

        public int CreateSingleImage(ImgProduct imgProduct) => ProductImageDAO.CreateSingle(imgProduct);

        public int DeleteSingleImageByProductId(long productId, long imageId) => ProductImageDAO.DeleteSingleByProductId(productId, imageId);

        public int DeleteListImageByProductId(long productId) => ProductImageDAO.DeleteListByProductId(productId);

        public int EditImage(long imageId, ImgProduct imgProduct) => ProductImageDAO.Edit(imageId, imgProduct);

        public List<TblProductImage> GetListImageByProductId(long productId) => ProductImageDAO.GetById(productId);

        public List<TblProductImage> GetListImageByProductId(long productId, int page, int take) => ProductImageDAO.GetById(productId, page, take);
    }
}
