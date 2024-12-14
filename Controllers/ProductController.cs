using EComputek.Models;
using EComputek.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComputek.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService services;
        private readonly ICategoryService cat;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;

        public ProductController(IProductService services, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env, ICategoryService cat)
        {
            this.services = services;
            this.env = env;
            this.cat = cat;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var res = services.GetAllProduct();
            return View(res);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(services.GetProductById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Category = cat.GetCategories();
            return View();  
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod, IFormFile file)
        {
            try
            {
                //to upload image in the images folder
                using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                prod.Imageurl = "~/images/" + file.FileName;
                var result = services.AddProduct(prod);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

            // GET: ProductController/Edit/5
            public ActionResult Edit(int id)
        {
            ViewBag.Category = cat.GetCategories();
            var res = services.GetProductById(id);
            TempData["oldUrl"] = res.Imageurl;
            TempData.Keep("oldUrl");
            return View(res);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod, IFormFile file)
        {
            try
            {
                string oldimgurl = TempData["oldUrl"].ToString();

                if (file != null)
                {
                    using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }

                    //to store img url only in database
                    prod.Imageurl = "~/images/" + file.FileName;

                    //to delect old image 
                    string[] str = oldimgurl.Split("/");
                    string str1 = (str[str.Length - 1]);
                    string path = env.WebRootPath + "\\images\\" + str1;
                    System.IO.File.Delete(path);
                }
                else
                {
                    prod.Imageurl = oldimgurl;
                }

                var res = services.UpdateProduct(prod);
                if (res == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = services.GetProductById(id);
            return View(res);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(Product prod)
        {

            try
            {
                var res = services.DeleteProductById(prod);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View();
                }

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}
