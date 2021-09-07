using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Model
{
    public class productVM
    {
        public int id { get; set; }
        public int? orderId { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public string description { get; set; }
        public Nullable<double> price { get; set; }
        public string code { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<int> numberOfProduct { get; set; }
        public Nullable<System.DateTime> cDate { get; set; }
    }
}
