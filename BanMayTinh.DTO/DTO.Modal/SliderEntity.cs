﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Modal
{
    public class SliderEntity
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Url { get; set; }

        public string? Description { get; set; }

        public string? Position { get; set; }

        public string? Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public byte? IsDelete { get; set; }

        public byte? IsActive { get; set; }
    }
}
