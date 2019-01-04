using BSMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSInterface
{
    public interface IAdminRepository: IRepository<Admin>
    {
        int Delete(int id);
    }
}
