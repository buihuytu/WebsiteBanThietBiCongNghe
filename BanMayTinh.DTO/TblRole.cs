using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblRole
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public byte? IsActive { get; set; }

    public byte? IsDelete { get; set; }

    public virtual ICollection<TblAccount> TblAccounts { get; set; } = new List<TblAccount>();
}
