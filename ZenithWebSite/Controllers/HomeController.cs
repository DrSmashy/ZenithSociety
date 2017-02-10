using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;

namespace ZenithWebSite.Controllers {
    public class HomeController : Controller {

        private ApplicationDbContext db = new ApplicationDbContext();

        private List<Event> getWeekEvents(DateTime date) {
            DateTime start = date.Date.AddDays(-(int)date.DayOfWeek);
            DateTime end = start.AddDays(7);
            var events = db.Events.Where(e => e.EventFromDate >= start
            & e.EventFromDate < end
            & e.IsActive == true).ToList();
            return events;
        }

        public ActionResult Index() {
            return View(getWeekEvents(DateTime.Today));
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}