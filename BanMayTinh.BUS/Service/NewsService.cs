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
    public class NewsService : INewsService
    {
        public int ChangeActive(long id, long updatedBy) => NewsDAO.ChangeActive(id, updatedBy);

        public int CreateNews(NewsImage news) => NewsDAO.Create(news);

        public int DeleteNews(long id) => NewsDAO.Delete(id);

        public int DelTrash(long id, long updatedBy) => NewsDAO.DelTrash(id, updatedBy);

        public List<NewsEntity> getAllNews(int isDelete) => NewsDAO.getAll(isDelete);

        public List<NewsEntity> getAllNews(int page, int take, int isDelete) => NewsDAO.getAll(page, take, isDelete);

        public NewsEntity getNewsById(long id) => NewsDAO.getById(id);

        public List<NewsEntity> getNewsByName(string name, int isDelete) => NewsDAO.getByName(name, isDelete);

        public List<NewsEntity> getNewsByName(string name, int page, int take, int isDelete) => NewsDAO.getByName(name, page, take, isDelete);

        public int ReTrash(long id, long updatedBy) => NewsDAO.ReTrash(id, updatedBy);

        public int UpdateNews(long id, NewsImage news) => NewsDAO.Update(id, news);
    }
}
