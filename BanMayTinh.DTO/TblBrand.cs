using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblBrand
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Image { get; set; }

    public long? IdCategory { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaKey { get; set; }

    public string? MetaDesc { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public byte? IsDelete { get; set; }

    public byte? IsActive { get; set; }

    public virtual TblCategory? IdCategoryNavigation { get; set; }

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
