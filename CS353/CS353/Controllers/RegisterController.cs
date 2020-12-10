using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS353.Models.Entity;
namespace CS353.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        DBCS353Entities db = new DBCS353Entities();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(TBLUser p)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            db.TBLUser.Add(p);
            db.SaveChanges();
            return RedirectToAction("Login", "Login");
        }
    }
}