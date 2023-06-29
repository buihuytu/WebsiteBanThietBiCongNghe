using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Image
{
    public class AccountImage
    {
        public string? Name { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public long? IdRole { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public long? CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }

        public byte? IsDelete { get; set; }

        public byte? IsActive { get; set; }

        public IFormFile? FileImage { get; set; }
    }
}
