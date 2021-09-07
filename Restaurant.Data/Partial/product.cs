using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Data
{
    public partial class product
    {
        public static product Clone(productVM productVm)
        {
            product x = new product();
            x.cDate = productVm.cDate;
            x.code = productVm.code;
            x.description = productVm.description;
            x.id = productVm.id;
            x.cDate = productVm.cDate;
            x.isActive = productVm.isActive;
            x.numberOfProduct = productVm.numberOfProduct;
            x.productName = productVm.productName;
            x.productImage = productVm.productImage;

            return x;
        }
    }
}
