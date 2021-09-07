using Restaurant.Abstract.IOrder;
using Restaurant.Data.Data;
using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Business.Order
{
    public class orderServices : IOrder
    {
        RestaurantEntities1 _DB = new RestaurantEntities1();
        public order AddToOrder(productVM product, int customerId)
        {
            try
            {
                if (product.orderId == -1)
                {
                    var model = new order()
                    {
                        customerId = customerId,
                        cDate = DateTime.Now,
                        price = product.numberOfProduct * product.price

                    };

                    _DB.orders.Add(model);
                    _DB.SaveChanges();

                    var orderDetaile = new orderDetaile()
                    {
                        orderId = model.id,
                        productId = product.id,
                        price = product.price,
                        amount = 1,
                        totalPrice = product.price * product.numberOfProduct


                    };


                    _DB.orderDetailes.Add(orderDetaile);
                    _DB.SaveChanges();
                    return model;
                }
                else
                {
                    var order = GetOrder(product.orderId.Value);
                    if (order != null)
                    {
                        var orderDetail = _DB.orderDetailes.FirstOrDefault(x => x.orderId == order.id && x.productId == product.id);
                        if (orderDetail != null)
                        {
                            orderDetail.amount += 1;
                            orderDetail.totalPrice = orderDetail.amount * orderDetail.price;
                            _DB.Entry(orderDetail).State = System.Data.Entity.EntityState.Modified;
                            _DB.SaveChanges();

                        }
                        else
                        {

                            var orderDetailes = new orderDetaile()
                            {
                                orderId = order.id,
                                productId = product.id,
                                price = product.price,
                                amount = 1,
                                totalPrice = product.price * product.numberOfProduct,
                                cDate = DateTime.Now



                            };
                            _DB.orderDetailes.Add(orderDetailes);
                            order.price = order.price + orderDetailes.totalPrice;
                            _DB.Entry(order).State = System.Data.Entity.EntityState.Modified;
                            _DB.SaveChanges();
                        }
                        return order;
                    }
                    else
                        return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public order GetOrder(int orderID)
        {
            return _DB.orders.FirstOrDefault(x => x.id == orderID);
        }
        public int GetByCusomerOrder(int customerId)
        {
            var order = _DB.orders.FirstOrDefault(x => x.customerId == customerId && (x.isCompleted == null || x.isCompleted==false));
            if (order != null)
                return order.id;
            return -1;
        }
        public int Paied(int id)
        {
            try
            {
                var result = _DB.orders.Where(y => y.customerId == id).ToList();
                foreach (var item in result)
                {
                    item.isCompleted = true;
                    _DB.SaveChanges();
                }
             
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(int orderId)
        {
            try
            {
                var result = _DB.orderDetailes.Where(y => y.orderId == orderId).FirstOrDefault();
                _DB.orderDetailes.Remove(result);
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
