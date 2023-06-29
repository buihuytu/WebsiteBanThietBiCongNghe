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
    public interface ISliderService
    {
        List<SliderEntity> GetAllSliders(int isDelete);

        List<SliderEntity> GetAllSliders(int page, int take, int isDelete);

        SliderEntity GetSliderById(long id);

        List<SliderEntity> GetSliderByName(string name, int isDelete);

        List<SliderEntity> GetSliderByName(string name, int page, int take, int isDelete);

        int AddSlider(SliderImage slider);

        int DeleteSlider(long id);

        int UpdateSlider(long id, SliderImage slider);

        int DelTrash(long id, long updatedBy);

        int ReTrash(long id, long updatedBy);

        int ChangeActive(long id, long updatedBy);
    }
}
