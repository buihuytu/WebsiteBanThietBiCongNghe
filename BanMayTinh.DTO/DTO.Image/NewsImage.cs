﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Image
{
    public class NewsImage
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public long? IdNewCategory { get; set; }

        public string? Contents { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaKey { get; set; }

        public string? MetaDesc { get; set; }

        public long? CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }

        public byte? IsActive { get; set; }

        public IFormFile? FileImage { get; set; }
    }
}