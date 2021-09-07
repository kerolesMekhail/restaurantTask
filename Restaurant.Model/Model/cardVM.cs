using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Model
{
    public class cardVM
    {
        public string  productName { get; set; }
        public Nullable<double> totalPrice { get; set; }
        public int orderId { get; set; }
        public string description { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public int? amount { get; set; }
    }
}
