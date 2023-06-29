using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Modal
{
    public class ProductEntity
    {
        public long ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Slug { get; set; }

        public string? Description { get; set; }

        public string? Detail { get; set; }

        public string? ProductImage { get; set; }

        public long? BrandId { get; set; }

        public string? BrandName { get; set; }

        public long? CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string? Specification { get; set; }

        public string? Feature { get; set; }

        public string? NewPromotion { get; set; }

        public long? ImPrice { get; set; }

        public long? Price { get; set; }

        public long? ProPrice { get; set; }

        public long? Quantity { get; set; }

        public string? Guarantee { get; set; }

        public string? Gift { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaKey { get; set; }

        public string? MetaDesc { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public byte? IsDelete { get; set; }

        public byte? IsActive { get; set; }

        public byte? IsDiscount { get; set; }

        public byte? IsHotProduct { get; set; }

    }
}
