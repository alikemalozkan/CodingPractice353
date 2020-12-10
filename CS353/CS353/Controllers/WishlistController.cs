using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS353.Models.Entity;
namespace CS353.Controllers
{
    public class WishlistController : Controller
    {
        // GET: Wishlist
        DBCS353Entities db = new DBCS353Entities();
        public ActionResult Index()
        {
            var list = db.TBLWishlist.ToList();
            return View(list);
        }
    }
}