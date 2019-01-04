using BSMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSInterface
{
    public interface ITransportRepository
    {
        List<Transport> GetAll();
        Transport Get(int id);
        int Insert(Transport transport);
        int Update(Transport transport);
        int DeleteTransport(Transport transport);
        List<Transport> GetAllTransport();
    }
}
