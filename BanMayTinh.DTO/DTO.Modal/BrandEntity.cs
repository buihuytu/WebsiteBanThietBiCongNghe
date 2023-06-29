using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Modal
{
    public class BrandEntity
    {
        public long BrandId { get; set; }

        public string? BrandName { get; set; }

        public string? Slug { get; set; }

        public string? BrandImage { get; set; }

        public long? IdCategory { get; set; }

        public string? CategoryName { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaKey { get; set; }

        public string? MetaDesc { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public byte? IsDelete { get; set; }

        public byte? IsActive { get; set; }
    }
}
