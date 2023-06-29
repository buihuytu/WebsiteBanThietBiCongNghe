using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Modal
{
    public class NewsEntity
    {
        public long NewsId { get; set; }

        public string? NewsName { get; set; }

        public string? NewsDescription { get; set; }

        public string? NewsImage { get; set; }

        public long? NewsCategoryId { get; set; }

        public string? NewsCategoryName { get; set; }

        public string? Contents { get; set; }

        public string? Slug { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaKey { get; set; }

        public string? MetaDesc { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedName { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedName { get; set; }

        public byte? IsDelete { get; set; }

        public byte? IsActive { get; set; }
    }
}
