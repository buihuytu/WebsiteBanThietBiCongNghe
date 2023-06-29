using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Modal
{
    public class RoleEntity
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedName { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedName { get; set; }

        public byte? IsActive { get; set; }

        public byte? IsDelete { get; set; }
    }
}
