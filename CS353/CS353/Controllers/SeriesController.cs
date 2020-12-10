using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS353.Models.Entity;
namespace CS353.Controllers
{
    public class SeriesController : Controller
    {
        DBCS353Entities db = new DBCS353Entities();
        // GET: Movie

        public ActionResult Index(string p)
        {
            var series = from k in db.TBLSeries select k;
            if (!string.IsNullOrEmpty(p))
            {
                series = series.Where(m => m.s_name.Contains(p));
            }
            return View(series.ToList());
        }
        [HttpGet]
        public ActionResult AddSeries()
        {
            List<SelectListItem> listOfGenres = (from i in db.TBLGenre.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.g_name,
                                                     Value = i.g_id.ToString()
                                                 }).ToList();
            ViewBag.selectedGenres = listOfGenres;
            return View();
        }
        [HttpPost]
        public ActionResult AddSeries(TBLSeries p)
        {
            var genre = db.TBLGenre.Where(c => c.g_id == p.TBLGenre.g_id).FirstOrDefault();
            p.TBLGenre = genre;
            db.TBLSeries.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSeries(int id)
        {
            var series = db.TBLSeries.Find(id);
            db.TBLSeries.Remove(series);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FindSeries(int id)
        {
            var series = db.TBLSeries.Find(id);
            List<SelectListItem> listOfGenres = (from i in db.TBLGenre.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.g_name,
                                                     Value = i.g_id.ToString()
                                                 }).ToList();
            ViewBag.selectedGenres = listOfGenres;
            return View("FindSeries", series);
        }
        public ActionResult UpdateSeries(TBLSeries p)
        {
            var series = db.TBLSeries.Find(p.s_id);
            series.s_name = p.s_name;
            series.s_numberOfSeason = p.s_numberOfSeason;
            series.s_numberOfEpisode = p.s_numberOfEpisode;
            var genre = db.TBLGenre.Where(c => c.g_id == p.TBLGenre.g_id).FirstOrDefault();
            series.s_genreID = genre.g_id;
            series.s_info = p.s_info;
            series.s_imdbPoint = p.s_imdbPoint;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}