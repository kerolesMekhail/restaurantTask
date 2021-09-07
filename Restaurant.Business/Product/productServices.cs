using Restaurant.Abstract.IProduct;
using Restaurant.Data.Data;
using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Business.Product
{
    public class productServices : IProduct
    {
        RestaurantEntities1 _DB = new RestaurantEntities1();
        public List<productVM> getAllProduct()
        {
            try
            {
                var result = (from p in _DB.products
                              where(p.isActive==true)
                              select new productVM
                              {
                                  cDate= p.cDate,
                                  code= p.code,
                                  description= p.description,
                                  id= p.id,
                                  isActive= p.isActive,
                                  numberOfProduct= p.numberOfProduct,
                                  price= p.price,
                                  productImage= p.productImage,
                                  productName= p.productName
                              }).ToList();
               
                return result;
            }
            catch(Exception ex)
            {
                return new List<productVM>();
            }
        }

        public List<cardVM> myCard(int CustomerId)
        {
            try
            {
                var result = (
                              from D in _DB.orders
                              join OD in _DB.orderDetailes on D.id equals OD.orderId
                              join P in _DB.products on OD.productId equals P.id
                              where(D.customerId== CustomerId & D.isCompleted != true )
                              select new cardVM
                              {
                                  productName = P.productName,
                                  totalPrice = P.price,
                                  orderId=D.id,
                                  amount=OD.amount
                              }
                            ).ToList();
                return result;
            }
            catch
            {
                return new List<cardVM>();
            }
        }

       
    }
}
