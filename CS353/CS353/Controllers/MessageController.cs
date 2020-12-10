using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS353.Models.Entity;
namespace CS353.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        DBCS353Entities db = new DBCS353Entities();
        public ActionResult Index()
        {
            var email = (string)Session["u_email"].ToString();
            var messages = db.TBLMessage.Where(x => x.m_to == email.ToString()).ToList();
            return View(messages);
        }
        public ActionResult SentMessage()
        {
            var email = (string)Session["u_email"].ToString();
            var messages = db.TBLMessage.Where(x => x.m_from == email.ToString()).ToList();
            return View(messages);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]

        public ActionResult NewMessage(TBLMessage p)
        {
            var email = (string)Session["u_email"].ToString();
            p.m_from = email.ToString();
            p.m_time = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("SentMessage", "Message");
        }
    }
}