using BSMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSInterface
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        int DeleteEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
    }
}
