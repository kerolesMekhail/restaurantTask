using Restaurant.Abstract.IOrder;
using Restaurant.Abstract.IProduct;
using Restaurant.Business.Order;
using Restaurant.Business.Product;
using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly IProduct _product;

        public OrderController()
        {
            _order = new orderServices();
            _product = new productServices();
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        } 
        
        //public ActionResult SaveOrder()
        //{
        //    return View();
        //} 
        [HttpGet]
        public ActionResult AddToOrder(int ProductID, int numberOfProduct)
        {
            var userId = Session["customerId"].ToString();

            int customerId = int.Parse(userId);
            var product = _product.getAllProduct().FirstOrDefault(x => x.id == ProductID);
           int  orderID= _order.GetByCusomerOrder(customerId);
            _order.AddToOrder(new productVM() { id = product.id, numberOfProduct = numberOfProduct, price = product.price, orderId = orderID }, customerId);
            return RedirectToAction("MyProduct","Product");
        }

        [HttpGet]
        public ActionResult CheckOut()
        {
            var userId = Session["customerId"].ToString();
           
            int customerId = int.Parse(userId);
            
            _order.Paied(customerId);
            return RedirectToAction("MyProduct", "Product");
        }  
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _order.Delete(id);
            return RedirectToAction("MyProduct", "Product");
        }
    }
}