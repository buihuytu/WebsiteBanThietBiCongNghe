using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Image
{
    public class CategoryImage
    {
        public string? Name { get; set; }

        public string? Notes { get; set; }

        public long? IdParent { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaKey { get; set; }

        public string? MetaDesc { get; set; }

        public long? CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }

        public byte? IsDelete { get; set; }

        public byte? IsActive { get; set; }

        public IFormFile? FileImage { get; set; }

    }
}
