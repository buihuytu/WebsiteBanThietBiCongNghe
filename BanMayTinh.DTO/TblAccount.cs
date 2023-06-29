using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblAccount
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public long? IdRole { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public byte? IsDelete { get; set; }

    public byte? IsActive { get; set; }

    public string? Avatar { get; set; }

    public virtual TblRole? IdRoleNavigation { get; set; }
}
