using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BSMSInterface;
using BSMSEntity;
using System.Net;
using System.Web.Http;
using BSMSRepository;

namespace BSMSApi.Controllers
{
    [System.Web.Http.RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAdminRepository adminRepository;
        private IEmployeeRepository employeeRepository;


        public AccountController()
        {
            this.adminRepository = new AdminRepository();
            this.employeeRepository = new EmployeeRepository();
        }
        [System.Web.Http.Route("")]
        public IHttpActionResult Post(Employee employee)
        {

            employee.UserId = Guid.NewGuid();
            employee.IsActive = true;
            this.employeeRepository.Insert(employee);
            string uri = Url.Link("GetById", new { id = employee.Id });
            return Created(uri, employee);
        }

        // GET: EmployeeList
        [System.Web.Http.Route("")]
        public IHttpActionResult Get()
        {
            
                List<Employee> EmployeeList = employeeRepository.GetAll();
                 return Ok(this.employeeRepository.GetAll());

        }
        //GetById
        [System.Web.Http.Route("{id}", Name ="GetById")]
        public IHttpActionResult Get(int id)
        {
            Employee emp = employeeRepository.Get(id);
            if (emp == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(emp);
            }
        }
        [System.Web.Http.Route("{id}")]
        public IHttpActionResult Put([FromBody]Employee employee, [FromUri]int id)
        {
            employee.Id = id;
            this.employeeRepository.UpdateEmployee(employee);
            return Ok(employee);
        }

        [System.Web.Http.Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            this.employeeRepository.DeleteEmployee(this.employeeRepository.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}