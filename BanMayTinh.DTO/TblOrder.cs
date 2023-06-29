using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblOrder
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public long? CustomerId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ExportedDate { get; set; }

    public long? TotalMoney { get; set; }

    public string? Notes { get; set; }

    public string? ReceiverName { get; set; }

    public string? ReceiverAddress { get; set; }

    public string? ReceiverEmail { get; set; }

    public string? ReceiverPhone { get; set; }

    public byte? IsDelete { get; set; }

    public byte? Status { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();
}
