using System;
using BSMSEntity;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSMSInterface;

namespace BSMSRepository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        DataContext context = new DataContext();
        public int DeleteEmployee(Employee employee)
        {
            Employee employeeUpdate = context.Employees.SingleOrDefault(e => e.Id == employee.Id);
            employeeUpdate.IsActive = false;
            return context.SaveChanges();
        }

        public int UpdateEmployee(Employee employee)
        {
            Employee employeeUpdate = context.Employees.SingleOrDefault(e => e.Id == employee.Id);
            employeeUpdate.FirstName = employee.FirstName;
            employeeUpdate.LastName = employee.LastName;
            employeeUpdate.PresentAddress = employee.PresentAddress;
            employeeUpdate.PermanentAddress = employee.PermanentAddress;
            employeeUpdate.PhoneNumber = employee.PhoneNumber;
            employeeUpdate.Email = employee.Email;
            return Update(employeeUpdate);
        }
        public int GetCount(string Role)
        {
            return context.Employees.Where(x => x.UserRole == Role).Count(); 
        }
        public Employee GetByUserId(string UserId)
        {
            return context.Employees.Where(x => x.UserId.ToString() == UserId).FirstOrDefault();
        }
        public Transport GetByTransportId(Guid TransportId)
        {
            return context.Transports.Where(x => x.TransPortId == TransportId).FirstOrDefault();
        }
    }
}
