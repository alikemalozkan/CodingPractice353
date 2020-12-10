using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS353.Models.Entity;
namespace CS353.Controllers
{
    public class EpisodeController : Controller
    {
        DBCS353Entities db = new DBCS353Entities();
        // GET: Movie

        public ActionResult Index(string p)
        {
            var episodes = from k in db.TBLEpisode select k;
            if (!string.IsNullOrEmpty(p))
            {
                episodes = episodes.Where(m => m.e_name.Contains(p));
            }
            return View(episodes.ToList());
        }
        [HttpGet]
        public ActionResult AddEpisode()
        {
            List<SelectListItem> listOfSeries = (from i in db.TBLSeries.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.s_name,
                                                     Value = i.s_id.ToString()
                                                 }).ToList();
            ViewBag.selectedSeries = listOfSeries;
            return View();
        }
        [HttpPost]
        public ActionResult AddEpisode(TBLEpisode p)
        {
            var series = db.TBLSeries.Where(c => c.s_id == p.TBLSeries.s_id).FirstOrDefault();

            p.TBLSeries = series;
            db.TBLEpisode.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEpisode(int id)
        {
            var episode = db.TBLEpisode.Find(id);
            db.TBLEpisode.Remove(episode);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FindEpisode(int id)
        {
            var episode = db.TBLEpisode.Find(id);
            List<SelectListItem> listOfSeries = (from i in db.TBLSeries.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.s_name,
                                                     Value = i.s_id.ToString()
                                                 }).ToList();
            ViewBag.selectedSeries = listOfSeries;
            return View("FindEpisode", episode);
        }
        public ActionResult UpdateEpisode(TBLEpisode p)
        {
            var episode = db.TBLEpisode.Find(p.e_id);
            episode.e_name = p.e_name;
            episode.e_duration = p.e_duration;
            var series = db.TBLSeries.Where(c => c.s_id == p.TBLSeries.s_id).FirstOrDefault();
            episode.e_seasonID = series.s_id;
            episode.e_info = p.e_info;
            episode.e_seasonNo = p.e_seasonNo;
            episode.e_episodeNo = p.e_episodeNo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}