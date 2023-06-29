using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Image
{
    public class ImgProduct
    {
        public long? IdProduct { get; set; }

        public IFormFile[]? FileImage { get; set; }
    }
}
