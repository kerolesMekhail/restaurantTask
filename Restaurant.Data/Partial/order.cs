using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Data
{
   public partial class order
    {
        public static order Clone(orderVM orderVM)
        {
            order x = new order();
            x.cDate = orderVM.cDate;
            x.customerId = orderVM.customerId;
            x.id = orderVM.id;
            x.numberOfPices = orderVM.numberOfPices;
            x.price = orderVM.price;
  
            return x;
        }
    }
}
