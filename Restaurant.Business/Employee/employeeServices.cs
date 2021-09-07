using Restaurant.Abstract.IEmployee;
using Restaurant.Data.Data;
using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Business.Employee
{
    public class employeeServices : IEmployee
    {
        RestaurantEntities1 _DB = new RestaurantEntities1();

        public cardVM Details(int Id)
        {
            try
            {
                var result = (
                              from D in _DB.orders
                              join OD in _DB.orderDetailes on D.id equals OD.orderId
                              join P in _DB.products on OD.productId equals P.id
                              join C in _DB.users on D.customerId equals C.id
                              where (D.isCompleted == true && D.isConfirmed != true)
                              select new cardVM
                              {
                                  productName = P.productName,
                                  totalPrice = P.price,
                                  orderId = D.id,
                                  description = P.description,
                                  UserName=C.userName,
                                  amount=OD.amount,
                                  FullName=C.fullName
                              }
                            ).FirstOrDefault();
                return result;
            }
            catch
            {
                return new cardVM();
            }
        }

        public List<cardVM> Orders(string search)
        {
            try
            {
                var result = (
                              from D in _DB.orders
                              join OD in _DB.orderDetailes on D.id equals OD.orderId
                              join P in _DB.products on OD.productId equals P.id
                              join c in _DB.users on D.customerId equals c.id
                              where (( D.isCompleted == true && D.isConfirmed != true && c.userName.Contains(search)) || (D.isCompleted == true && D.isConfirmed != true && search==null)|| (D.isCompleted == true && D.isConfirmed != true && search == ""))
                              select new cardVM
                              {
                                  productName = P.productName,
                                  totalPrice = P.price,
                                  orderId = D.id,
                                  description=P.description,
                                  amount=OD.amount,
                                  FullName=c.fullName,
                                  UserName=c.userName
                              }
                            ).ToList();
                return result;
            }
            catch
            {
                return new List<cardVM>();
            }
        }
        public int Confirmed(int id)
        {
            try
            {
                var result = _DB.orders.Where(y => y.id == id).FirstOrDefault();

                    result.isConfirmed = true;
                    _DB.SaveChanges();
                

                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
