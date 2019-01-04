using BSMSEntity;
using BSMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class TimeScheduleController : Controller
    {
        TimeScheduleRepository timeScheduleRepository = new TimeScheduleRepository();
        TransportRepository transportRepository = new TransportRepository();
        EmployeeRepository employeeRepository = new EmployeeRepository();
        // GET: TimeSchedule
        [HttpGet]
        public ActionResult AddSchedule()
        {
            if (Session["User"] != null)
            {
                List<SelectListItem> TransPortList = new List<SelectListItem>();
            TransPortList.AddRange(transportRepository.GetAll().Select(x =>
                       new SelectListItem()
                       {
                           Text = x.TransportNo.ToString(),
                           Value = x.TransPortId.ToString()
                       }).ToList());
            ViewBag.TransPortList = TransPortList;

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
        public ActionResult AddSchedule(TimeSchedule timeSchedule)
        {
            if (ModelState.IsValid)
            {
                Guid UserId = transportRepository.GetByTransportId(timeSchedule.TransportId).DriverId;
                timeSchedule.UserId = UserId;
                timeSchedule.IsActive = true;
                timeScheduleRepository.Insert(timeSchedule);


                return RedirectToAction("ViewTimeSchedule", "TimeSchedule");
            }
            return RedirectToAction("AddSchedule", "TimeSchedule");
        }

        [HttpGet]
        public ActionResult ViewTimeSchedule()
        {
            if (Session["User"] != null)
            {
                Employee emp = null;
                Transport transport = null;
                List<TimeSchedule> scheduleList = timeScheduleRepository.GetAll();
                foreach (var item in scheduleList)
                {
                    emp = employeeRepository.GetByUserId(item.UserId.ToString());

                    
                    transport = transportRepository.GetByTransportId(item.TransportId);
                    item.TransportNo = transport.TransportNo;
                    item.Name = emp.FirstName + " " + emp.LastName;


                }
                return View(scheduleList);
            }
            else return Redirect("/");

        }

        [HttpGet]
        public ActionResult DeleteSchedule(TimeSchedule time)
        {
            if (Session["User"] != null)
            {

                TimeSchedule timeSchedule = timeScheduleRepository.Get(time.Id);
                return View(timeSchedule);
            }
            else return Redirect("/");
        }

        [HttpPost, ActionName("DeleteSchedule")]
        public ActionResult DeleteConfirm(TimeSchedule  time)
        {
            timeScheduleRepository.Delete(time);
            return RedirectToAction("ViewTimeSchedule", "TimeSchedule");

        }

        [HttpGet]
        public ActionResult EditTimeSchedule(int id)
        {
            if (Session["User"] != null)
            {
                TimeSchedule timeSchedule = timeScheduleRepository.Get(id);
                return View(timeSchedule);
            }
            else return Redirect("/");

        }

        [HttpPost, ActionName("EditTimeSchedule")]
        public ActionResult EditTimeSchedule(TimeSchedule timeSchedule)
        {
            timeScheduleRepository.Update(timeSchedule);
            return RedirectToAction("ViewTimeSchedule", "TimeSchedule", new { id = timeSchedule.Id });

        }

    }
}

