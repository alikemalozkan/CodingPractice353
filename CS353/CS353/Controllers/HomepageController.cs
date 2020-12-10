using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS353.Models.Entity;
namespace SHOPPING.Controllers
{
    public class HomepageController : Controller
    {
        // GET: HomePage
        DBCS353Entities db = new DBCS353Entities();

        [HttpGet]
        public ActionResult Index()
        {
            var list = db.TBLMovie.ToList();
            return View(list);
        }
        
}