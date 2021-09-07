using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Data
{
    public partial class orderDetaile
    {
        public static orderDetaile Clone(orderDetailesVM orderDetaileVM)
        {
            orderDetaile x = new orderDetaile();
            x.cDate = orderDetaileVM.cDate;
            x.id = orderDetaileVM.id;
            x.isActive = orderDetaileVM.isActive;
            x.productId = orderDetaileVM.productId;           
            return x;
        }
    }
}
