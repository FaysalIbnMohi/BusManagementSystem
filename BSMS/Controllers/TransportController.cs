using BSMSEntity;
using BSMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSMS.Controllers
{
    public class TransportController : Controller
    {
        // GET: Transport
        TransportRepository transportRepository = new TransportRepository();
        EmployeeRepository employeeRepository = new EmployeeRepository();


        [HttpGet]
        public ActionResult AddTransport( )
        {

            if (Session["User"] != null)
            {
                List<SelectListItem> DriverList = new List<SelectListItem>();
                DriverList.AddRange(employeeRepository.GetAll().Where(e => e.UserRole == "Driver" && e.IsActive == true).Select(X =>
                  new SelectListItem()
                  {
                      Text = X.FirstName + " " + X.LastName,
                      Value = X.UserId.ToString()
                  }).ToList());
                ViewBag.DriverList = DriverList;
                return View();
            }
            else return Redirect("/");
        }

        [HttpPost]
        public ActionResult AddTransport(Transport transport)
        {
            if(ModelState.IsValid)
            {
                transport.TransPortId = Guid.NewGuid();
                transport.IsActive = true;
                transportRepository.Insert(transport);
               return RedirectToAction("ViewTransport","Transport");
            }
            ViewBag.Error = "Something Wrong!!!";
            return RedirectToAction("AddTransport", "Transport");
        }


        [HttpGet]
        public ActionResult ViewTransport()
        {
            if (Session["User"] != null)
            {
                Employee emp = null;
                List<Transport> transportList = transportRepository.GetAll();

                foreach (var item in transportList)
                {
                    emp = employeeRepository.GetByUserId(item.DriverId.ToString());

                    item.Name = emp.FirstName + " " + emp.LastName;
                }


                return View(transportList);
            }
            else return Redirect("/");
        }



        [HttpGet]
        public ActionResult DeleteTransport(int id)
        {
            if (Session["User"] != null)
            {
                Transport transport = transportRepository.Get(id);
                return View(transport);
            }
            else return Redirect("/");
        }

        [HttpPost, ActionName("DeleteTransport")]
        public ActionResult DeleteConfirm(Transport transport)
        {
          //  transportRepository.DeleteTransport(transport.Id);
            return RedirectToAction("ViewTransport", "Transport");

        }

        [HttpGet]
        public ActionResult EditTransport(int id)
        {
            if (Session["User"] != null)
            {
                Transport transport = transportRepository.Get(id);
                return View(transport);
            }
            else return Redirect("/");
        }

        [HttpPost, ActionName("EditTransport")]
        public ActionResult EditTransport(Transport transport)
        {
            transportRepository.Update(transport);
            return RedirectToAction("ViewTransport", "Transport", new { id = transport.Id });

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["User"] != null)
            {
                Transport transport = transportRepository.Get(id);
                return View(transport);
            }
            else return Redirect("/");
        }




    }
}