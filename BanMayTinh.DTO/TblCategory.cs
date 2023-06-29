using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblCategory
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Notes { get; set; }

    public string? Icon { get; set; }

    public long? IdParent { get; set; }

    public string? Slug { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaKey { get; set; }

    public string? MetaDesc { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public byte? IsDelete { get; set; }

    public byte? IsActive { get; set; }

    public virtual ICollection<TblBrand> TblBrands { get; set; } = new List<TblBrand>();

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
