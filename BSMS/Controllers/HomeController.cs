using BSMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSMS.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home
        AdminRepository repo = new AdminRepository();





        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                repo.GetAll();
                return View();
            }
            else return Redirect("/");
        }

        
    }
}