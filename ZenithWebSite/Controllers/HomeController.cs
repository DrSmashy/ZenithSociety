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

        private int getWeekNumber(DateTime dt) {
            var currCulture = CultureInfo.CurrentCulture;

            return currCulture.Calendar.GetWeekOfYear(
                        dt,
                        currCulture.DateTimeFormat.CalendarWeekRule,
                        currCulture.DateTimeFormat.FirstDayOfWeek);
        }

        public ActionResult Index() {
            var startDay = DateTime.Today.AddDays(-1);
            var endDay = DateTime.Today.AddDays(7);

            var events = db.Events.Where(e => e.EventFromDate >= startDay
            & e.EventFromDate < endDay
            & e.IsActive == true).ToList();
            return View(events);
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