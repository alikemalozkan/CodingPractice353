using CS353.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace CS353.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBCS353Entities db = new DBCS353Entities();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLUser p)
        {
            var info = db.TBLUser.FirstOrDefault(x => x.u_email == p.u_email && x.u_password == p.u_password);
            if (info != null)
            {

                if (string.Equals(p.u_email.ToString(), "admin@admin") && string.Equals(p.u_password.ToString(), "admin"))
                {
                    return RedirectToAction("Index", "Movie");
                }
                else
                {
                    Console.WriteLine();
                    FormsAuthentication.SetAuthCookie(info.u_email, false);
                    Session["u_email"] = info.u_email.ToString();
                    return RedirectToAction("Index", "UserPage");
                }
            }
            else
            {
                return View();
            }
        }

    }
}