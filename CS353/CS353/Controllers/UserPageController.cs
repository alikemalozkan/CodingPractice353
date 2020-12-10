using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS353.Models.Entity;
namespace CS353.Controllers
{
    public class UserPageController : Controller
    {
        DBCS353Entities db = new DBCS353Entities();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var email = (string)Session["u_email"];
            var user = db.TBLUser.FirstOrDefault(x => x.u_email == email);
            return View(user);
        }
        [HttpPost]
        public ActionResult Index2(TBLUser p)
        {
            var email = (string)Session["u_email"];
            var user = db.TBLUser.FirstOrDefault(x => x.u_email == email);
            user.u_name = p.u_name;
            user.u_surname = p.u_surname;
            user.u_password = p.u_password;
            user.u_preferenceList = p.u_preferenceList;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Wishlist()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Wishlist(TBLWishlist w)
        {
            var email = (string)Session["u_email"].ToString();
            w.w_user = email.ToString();
            db.TBLWishlist.Add(w);
            db.SaveChanges();
            return RedirectToAction("Wishlist");
        }

        [HttpGet]
        public ActionResult Wall()
        {
            return View();
        }
    }
}
