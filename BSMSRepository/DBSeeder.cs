using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BSMSEntity;

namespace BSMSRepository
{
    public class DBSeeder : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            Admin admin = new Admin
            {
                FirstName = "Tom",
                LastName = "Jerry",
                PermanentAddress = "Nikunja",
                PresentAddress = "Uttara",
                Email = "huha@gmail.com",
                Password = "123",
                Salary = 1200000.0,
                PhoneNumber = "01715599773",
                UserId = Guid.NewGuid(),
                IsActive = true
            };
            context.Admins.Add(admin);
            context.SaveChanges();
        }
    }
}