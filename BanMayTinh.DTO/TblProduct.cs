using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblProduct
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public long? IdBrand { get; set; }

    public long? IdCategory { get; set; }

    public string? Specification { get; set; }

    public string? Feature { get; set; }

    public string? NewPromotion { get; set; }

    public long? Price { get; set; }

    public long? ProPrice { get; set; }

    public string? Guarantee { get; set; }

    public string? Gift { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaKey { get; set; }

    public string? MetaDesc { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public byte? IsDelete { get; set; }

    public byte? IsActive { get; set; }

    public byte? IsDiscount { get; set; }

    public byte? IsHotProduct { get; set; }

    public long? ImPrice { get; set; }

    public long? Quantity { get; set; }

    public virtual TblBrand? IdBrandNavigation { get; set; }

    public virtual TblCategory? IdCategoryNavigation { get; set; }

    public virtual ICollection<TblProductImage> TblProductImages { get; set; } = new List<TblProductImage>();
}
