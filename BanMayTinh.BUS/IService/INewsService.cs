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
    public interface INewsService
    {
        List<NewsEntity> getAllNews(int isDelete);

        List<NewsEntity> getAllNews(int page, int take, int isDelete);

        NewsEntity getNewsById(long id);

        List<NewsEntity> getNewsByName(string name, int isDelete);

        List<NewsEntity> getNewsByName(string name, int page, int take, int isDelete);

        int CreateNews(NewsImage news);

        int UpdateNews(long id, NewsImage news);

        int DeleteNews(long id);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);

        int ChangeActive(long id, long updatedBy);
    }
}
