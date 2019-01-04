
using BSMSEntity;
using BSMSRepository;
using BSMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        EmployeeRepository employeeRepository = new EmployeeRepository();
        AdminRepository adminRepository = new AdminRepository();
        public ActionResult Login()
        {
            if (Session["User"]!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost, ActionName("Login")]
        public ActionResult LoginConfirmed(FormCollection forms)
        {
            string Email = forms["EmailAddress"];
            string Password = forms["Password"];
            Admin admin = adminRepository.GetByEmail(Email);
            if(admin != null)
            {
                Session["User"] = admin.Email;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            if (Session["User"] != null)
            {

                List<SelectListItem> UserRole = new List<SelectListItem>();
                UserRole.Add(
                           new SelectListItem()
                           {
                               Text = "Manager",
                               Value = "Manager"
                           });
                UserRole.Add(
                           new SelectListItem()
                           {
                               Text = "Driver",
                               Value = "Driver"
                           });
                UserRole.Add(
                           new SelectListItem()
                           {
                               Text = "Supervisor",
                               Value = "Supervisor"
                           });
                UserRole.Add(
                           new SelectListItem()
                           {
                               Text = "Helper",
                               Value = "Helper"
                           });
                UserRole.Add(
                 new SelectListItem()
                 {
                     Text = "Counter Manager",
                     Value = "CounterManager"
                 });
                ViewBag.UserRole = UserRole;
                return View();
            }
            else return Redirect("/");
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {

            if (ModelState.IsValid)
            {
                emp.UserId = Guid.NewGuid();
                emp.IsActive = true;
                employeeRepository.Insert(emp);
                return RedirectToAction("EmployeeList", "Account");
            }
            return RedirectToAction("AddEmployee", "Account");
        }
        [HttpGet]
        public ActionResult EmployeeList()
        {
            if (Session["User"] != null)
            {

                List<Employee> EmployeeList = employeeRepository.GetAll();
                return View(EmployeeList);
            }
            else return Redirect("/");
        }

        [HttpGet]
        public ActionResult EmployeeDetails(int id)
        {
            if (Session["User"] != null)
            {
                Employee emp = employeeRepository.Get(id);
                return View(emp);
            }
            else return Redirect("/");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["User"] != null)
            {
                Employee emp = employeeRepository.Get(id);
                return View(emp);
            }
            else return Redirect("/");
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            employeeRepository.Update(emp);
            return RedirectToAction("EmployeeDetails", "Account",new {id=emp.Id });

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["User"] != null)
            {
                Employee emp = employeeRepository.Get(id);
                return View(emp);
            }
            else return Redirect("/");

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            employeeRepository.Delete(employeeRepository.Get(id));
            return RedirectToAction("EmployeeList", "Account");

        }
        public ActionResult SignOut()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Account");

        }

        public ActionResult Report()
        {
            if (Session["User"] != null)
            {
                List<ReportModel> model = new List<ReportModel>();
                List<Employee> emp = employeeRepository.GetAll();

                foreach (var item in emp)
                {
                    model.Add(new ReportModel
                    {
                        UserRole = item.UserRole,
                        Count = employeeRepository.GetCount(item.UserRole)
                    });
                }
                return View(model);
            }

            else return Redirect("/");
        }




    }
}