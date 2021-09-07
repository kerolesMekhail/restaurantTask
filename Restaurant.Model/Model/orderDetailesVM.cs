using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Model
{
    public class orderDetailesVM
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int customerId { get; set; }
        public bool isActive { get; set; }
        public System.DateTime cDate { get; set; }
    }
}
