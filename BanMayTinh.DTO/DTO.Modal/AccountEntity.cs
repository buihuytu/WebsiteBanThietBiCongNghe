using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Modal
{
    public class AccountEntity
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Avatar { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public long? RoleId { get; set; }

        public string? RoleName { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedName { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedName { get; set; }

        public byte? IsDelete { get; set; }

        public byte? IsActive { get; set; }
    }
}
