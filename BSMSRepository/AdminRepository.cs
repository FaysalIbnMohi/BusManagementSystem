using BSMSEntity;
using BSMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSRepository
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        DataContext context = new DataContext();

        public int Delete(int id)
        {
            Admin adminUpdate = context.Admins.SingleOrDefault(e => e.Id == id);
            adminUpdate.IsActive = false;
            return context.SaveChanges();

        }

        public Admin GetByEmail(string Email)
        {
            return context.Admins.Where(e => e.Email == Email).SingleOrDefault();
        }

        public int UpdateAdmin(Admin Admin)
        {
            Admin adminUpdate = context.Admins.SingleOrDefault(e => e.Id == Admin.Id);
            adminUpdate.FirstName = Admin.FirstName;
            adminUpdate.LastName = Admin.LastName;
            adminUpdate.Email = Admin.Email;
            adminUpdate.PresentAddress = Admin.PresentAddress;
            adminUpdate.PermanentAddress = Admin.PermanentAddress;
            adminUpdate.PhoneNumber = Admin.PhoneNumber;
            adminUpdate.Salary = Admin.Salary;
            adminUpdate.Password = Admin.Password;
            return context.SaveChanges();
        }
    }
}
