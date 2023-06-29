using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.UTILITIES.Library
{
    public class ModelCart
    {
        public long ProductID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public string Image { get; set; }
    }
}
