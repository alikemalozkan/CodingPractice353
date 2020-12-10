using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS353.Models.Entity;

namespace CS353.Controllers
{
    public class GenreController : Controller
    {
        DBCS353Entities db = new DBCS353Entities();
        public ActionResult Index()
        {
            var list = db.TBLGenre.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddGenre()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGenre(TBLGenre p)
        {
            db.TBLGenre.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteGenre(int id)
        {
            var genre = db.TBLGenre.Find(id);
            db.TBLGenre.Remove(genre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FindGenre(int id)
        {
            var genre = db.TBLGenre.Find(id);
            return View("FindGenre", genre);
        }
        public ActionResult UpdateGenre(TBLGenre p)
        {
            var genre = db.TBLGenre.Find(p.g_id);
            genre.g_name = p.g_name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}