using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Model
{
    public class orderVM
    {
         public int id { get; set; }
        public Nullable<int> customerId { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<int> amount { get; set; }
        public System.DateTime cDate { get; set; }
        public Nullable<int> numberOfPices { get; set; }
    }
}
