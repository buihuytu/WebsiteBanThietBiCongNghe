using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DTO.DTO.Modal
{
    public class OrderEntity
    {
        public long Id { get; set; }

        public string? Code { get; set; }

        public long? CustomerId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ExportedDate { get; set; }

        public string? Notes { get; set; }

        public string? ReceiverName { get; set; }

        public string? ReceiverAddress { get; set; }

        public string? ReceiverEmail { get; set; }

        public string? ReceiverPhone { get; set; }

        public byte? Status { get; set; }

        public string? UpdatedName { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
