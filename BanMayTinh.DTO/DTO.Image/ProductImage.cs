using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Image
{
    public class ProductImage
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Detail { get; set; }

        public long? IdBrand { get; set; }

        public long? IdCategory { get; set; }

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

        public long? CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }

        public byte? IsActive { get; set; }

        public byte? IsDiscount { get; set; }

        public byte? IsHotProduct { get; set; }

        public IFormFile? FileImage { get; set; }

    }
}
