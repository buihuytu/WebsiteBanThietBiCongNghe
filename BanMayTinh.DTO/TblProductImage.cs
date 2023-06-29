using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblProductImage
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? IdProduct { get; set; }

    public virtual TblProduct? IdProductNavigation { get; set; }
}
