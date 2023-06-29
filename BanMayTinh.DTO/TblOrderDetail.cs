using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblOrderDetail
{
    public long Id { get; set; }

    public long? OrderId { get; set; }

    public long? ProductId { get; set; }

    public long? Price { get; set; }

    public int? Quantity { get; set; }

    public long? Total { get; set; }

    public virtual TblOrder? Order { get; set; }
}
