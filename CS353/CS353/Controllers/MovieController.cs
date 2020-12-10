using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS353.Models.Entity;
namespace CS353.Controllers
{
    public class MovieController : Controller
    {
  
        DBCS353Entities db = new DBCS353Entities();
        // GET: Movie
 
        public ActionResult Index(string p)
        {
            var movies = from k in db.TBLMovie select k;
            if (!string.IsNullOrEmpty(p))
            {
                movies = movies.Where(m => m.m_name.Contains(p));
            }
            return View(movies.ToList());
        }
        [HttpGet]
        public ActionResult AddMovie()
        {
            List<SelectListItem> listOfGenres = (from i in db.TBLGenre.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = i.g_name,
                                                         Value = i.g_id.ToString()
                                                     }).ToList();
            ViewBag.selectedGenre = listOfGenres;           
            return View();
        }
        [HttpPost]
        public ActionResult AddMovie(TBLMovie p)
        {
            var genre = db.TBLGenre.Where(c => c.g_id == p.TBLGenre.g_id).FirstOrDefault();
           
            p.TBLGenre = genre;
            db.TBLMovie.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMovie(int id)
        {
            var movie = db.TBLMovie.Find(id);
            db.TBLMovie.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FindMovie(int id)
        {
            var movie = db.TBLMovie.Find(id);
            List<SelectListItem> listOfGenres = (from i in db.TBLGenre.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = i.g_name,
                                                         Value = i.g_id.ToString()
                                                     }).ToList();
            ViewBag.selectedGenres = listOfGenres;
            return View("FindMovie", movie);
        }
        public ActionResult UpdateMovie(TBLMovie p)
        {
            var movie = db.TBLMovie.Find(p.m_id);
            movie.m_name = p.m_name;
            movie.m_duration = p.m_duration;
            var genre = db.TBLGenre.Where(c => c.g_id == p.TBLGenre.g_id).FirstOrDefault();
            movie.m_genreID = genre.g_id;
            movie.m_info = p.m_info;
            movie.m_imdbPoint = p.m_imdbPoint;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}