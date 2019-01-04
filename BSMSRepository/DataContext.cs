using BSMSEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BSMSRepository
{
    public class DataContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeSchedule> TimeSchedules{ get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<SeatBooking> SeatBooking { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

    }
}
