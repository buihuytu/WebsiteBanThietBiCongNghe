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
    public class SliderService : ISliderService
    {
        public int AddSlider(SliderImage slider) => SliderDAO.Add(slider);

        public int ChangeActive(long id, long updatedBy) => SliderDAO.ChangeActive(id, updatedBy);

        public int DeleteSlider(long id) => SliderDAO.Delete(id);

        public int DelTrash(long id, long updatedBy) => SliderDAO.DelTrash(id, updatedBy);

        public List<SliderEntity> GetAllSliders(int isDelete) => SliderDAO.getAll(isDelete);

        public List<SliderEntity> GetAllSliders(int page, int take, int isDelete) => SliderDAO.getAll(page, take, isDelete);

        public SliderEntity GetSliderById(long id) => SliderDAO.getById(id);

        public List<SliderEntity> GetSliderByName(string name, int isDelete) => SliderDAO.getByName(name, isDelete);

        public List<SliderEntity> GetSliderByName(string name, int page, int take, int isDelete) => SliderDAO.getByName(name, page, take, isDelete);

        public int ReTrash(long id, long updatedBy) => SliderDAO.ReTrash(id, updatedBy);

        public int UpdateSlider(long id, SliderImage slider) => SliderDAO.Update(id, slider);
    }
}
