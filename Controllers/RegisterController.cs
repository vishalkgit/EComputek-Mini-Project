using EComputek.Models;
using EComputek.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EComputek.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterationService services;

        public RegisterController(IRegisterationService services)
        {
            this.services = services;
        }


        // GET: RegisterController
        public ActionResult Index()
        {
            var res = services.GetAllUser();
            return View(res);
        }

        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            var res = services.GetById(id);
            return View(res);
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registeration user)
        {
            try
            {
                user.roleid = 2;
                var res = services.AddUser(user);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View("Create");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: RegistrationController/Create
        //---------------------- Registration ------
        public ActionResult Login()
        {
            return View();
        }


        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            try
            {
                var res = services.Login(email, password);
                if (res != null)
                {
                    if (res.roleid == 1)
                    {
                        HttpContext.Session.SetInt32("Admin", res.roleid);
                        HttpContext.Session.SetString("Admin", res.Firstname);
                        HttpContext.Session.SetInt32("user_id", res.Userid);
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Customer", res.Firstname);
                        HttpContext.Session.SetInt32("user_id", res.Userid);
                        return RedirectToAction("DisplayProduct", "DisplayProducts");
                    }
                }
                else
                {
                    ViewBag.Error = "Incorrect password or email";
                    return View("Login");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }




        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = services.GetById(id);
            return View(res);
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registeration registration)
        {
            try
            {
                var res = services.UpdateUser(registration);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = services.GetById(id);
            return View(res);
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var res = services.DeleteUser(id);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
