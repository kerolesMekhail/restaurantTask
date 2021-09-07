using Restaurant.Abstract.IProduct;
using Restaurant.Business.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        public ProductController()
        {
            _product = new productServices();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetProducts()
        {
            return View(_product.getAllProduct());
        }
        public ActionResult MyProduct()
        {
            var id = Session["customerId"].ToString();
            int customerId = int.Parse(id);
            return View(_product.myCard(customerId));
        }
        
       
    }
}