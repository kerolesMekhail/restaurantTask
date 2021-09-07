using Restaurant.Data.Data;
using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Abstract.IOrder
{
    public interface IOrder
    {
        order AddToOrder(productVM product, int customerId);
        int Paied(int id);
        int Delete(int orderId);
        int GetByCusomerOrder(int customerId);
        order GetOrder(int orderID);


    }
}
