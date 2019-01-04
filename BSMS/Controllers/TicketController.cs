using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class TicketController : Controller
    {
        // GET: Tickeet
        public ActionResult Index()
        {
            return View();
        }
    }
}