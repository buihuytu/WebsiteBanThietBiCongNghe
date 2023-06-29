using System;
using System.Collections.Generic;

namespace BanMayTinh.DTO;

public partial class TblSlider
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Description { get; set; }

    public long? Position { get; set; }

    public string? Image { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public byte? IsDelete { get; set; }

    public byte? IsActive { get; set; }
}
