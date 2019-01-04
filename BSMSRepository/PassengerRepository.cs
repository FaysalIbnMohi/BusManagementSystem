using BSMSEntity;
using BSMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSRepository
{
    public class PassengerRepository : Repository<Passenger>, IPassengerRepository
    {
        DataContext context = new DataContext();


        public int UpdatePassenger(Passenger passenger)
        {
            Passenger passengerUpdate = context.Passengers.SingleOrDefault(e => e.Id == passenger.Id);
            passengerUpdate.Name = passenger.Name;
            passengerUpdate.Email = passenger.Email;
            passengerUpdate.Phone = passenger.Phone;
            passengerUpdate.Password = passenger.Password;
            
            return Update(passengerUpdate);
        }
    }
}
