using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Modal
{
    public class CategoryEntity
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Notes { get; set; }

        public string? Icon { get; set; }

        public long? ParentId { get; set; }

        public string? ParentName { get; set; }

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
