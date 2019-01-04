using BSMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSInterface
{
    public interface IPassengerRepository : IRepository<Passenger>
    {
        //int DeletePassenger(Passenger passenger);
        int UpdatePassenger(Passenger passenger);
    }
}
