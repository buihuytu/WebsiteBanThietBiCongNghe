using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblContact
{
    public long Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Enquiry { get; set; }

    public string? Reply { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? RepliedBy { get; set; }

    public DateTime? RepliedDate { get; set; }

    public byte? IsDelete { get; set; }

    public byte? IsReply { get; set; }
}
