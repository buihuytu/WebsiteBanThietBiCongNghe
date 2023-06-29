using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.BUS.IService
{
    public interface IProductImageService
    {
        List<TblProductImage> GetListImageByProductId(long productId);

        List<TblProductImage> GetListImageByProductId(long productId, int page, int take);

        int CreateSingleImage(ImgProduct imgProduct);

        int DeleteSingleImageByProductId(long productId, long imageId);

        int DeleteListImageByProductId(long productId);

        int CreateListImages(ImgProduct imgProduct);

        int EditImage(long imageId, ImgProduct imgProduct);
    }
}
