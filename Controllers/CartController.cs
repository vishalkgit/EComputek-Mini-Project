using EComputek.Data;
using EComputek.Models;
using EComputek.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComputek.Controllers
{
   



    public class CartController : Controller
    {
        private readonly ICartService cart_services;
        private readonly IProductService prod_services;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;
        private readonly ApplicationDBContext db;

        public CartController(ICartService cart_services, IProductService prod_services, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env, ApplicationDBContext db)
        {
            this.cart_services = cart_services;
            this.prod_services = prod_services;
            this.env = env;
            this.db = db;
        }


        // GET: CartController
        public ActionResult Index()
        {
            int userid = (int)HttpContext.Session.GetInt32("user_id");
            var res = cart_services.GetCartById(userid);
            return View(res);
        }


        [HttpGet]
        public IActionResult AddToCart(int productId)
        {
            try
            {
                if (productId == 0)
                {
                    ViewBag.Error = "Invalid product ID.";
                    return RedirectToAction("DisplayProduct", "DisplayProducts");
                }

                int userid = (int)HttpContext.Session.GetInt32("user_id");

                var res = prod_services.GetProductById(productId);
                if (res != null)
                {
                    cart_services.AddtoCart(new Cart
                    {
                        Productid = res.Productid,
                        Userid = userid,
                        Price = res.Price,
                        Name = res.Name,
                        Quantity = 1
                    });
                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    ViewBag.Error = "Error to add product into cart !";
                    return RedirectToAction("DisplayProduct", "DisplayProducts");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("DisplayProduct", "DisplayProducts");

            }
        }

        public IActionResult UpdateQuantity(Cart cart)
        {
            try
            {
                int userid = (int)HttpContext.Session.GetInt32("user_id");
                var res = cart_services.Update(cart);
                if (res != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error to  update quantity !";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Cart");
            }
        }


        public IActionResult Delete(int id)
        {
            try
            {
                var res = cart_services.Delete(id);
                if (res >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error to  delete cart !";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Cart");
            }
        }


        //// GET: CartController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: CartController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CartController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CartController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CartController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CartController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CartController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
