using EComputek.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComputek.Controllers
{
    public class DisplayProductsController : Controller
    {

        private readonly IProductService services;
        private readonly ICategoryService cat;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;


        public DisplayProductsController(IProductService services, ICategoryService cat, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.services = services;
            this.cat = cat;
            this.env = env;
        }


        //Display Product
        public IActionResult DisplayProduct()
        {
            var res = services.GetAllProduct();
            return View(res);
        }



        // GET: DisplayProdutcsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DisplayProdutcsController/Details/5
        public ActionResult Details(int id)
        {
            var res = services.GetProductById(id);
            return View(res);
        }

        // GET: DisplayProdutcsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisplayProdutcsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisplayProdutcsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisplayProdutcsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisplayProdutcsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisplayProdutcsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
