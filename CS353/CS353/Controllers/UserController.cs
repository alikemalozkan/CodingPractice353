using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CS353.Models.Entity;
namespace CS353.Controllers
{
    public class UserController : Controller
    {
      
        DBCS353Entities db = new DBCS353Entities();
        public ActionResult Index(int pageNumber = 1)
        {
            var list = db.TBLUser.ToList().ToPagedList(pageNumber, 5);
            return View(list);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(TBLUser p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddUser");
            }
            db.TBLUser.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(int id)
        {
            var user = db.TBLUser.Find(id);
            db.TBLUser.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FindUser(int id)
        {
            var user = db.TBLUser.Find(id);
            return View("FindUser", user);
        }
        public ActionResult UpdateUser(TBLUser p)
        {
            var user = db.TBLUser.Find(p.u_id);
            user.u_name = p.u_name;
            user.u_surname = p.u_surname;
            user.u_email = p.u_email;
            user.u_password = p.u_password;
            user.u_preferenceList = p.u_preferenceList;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}