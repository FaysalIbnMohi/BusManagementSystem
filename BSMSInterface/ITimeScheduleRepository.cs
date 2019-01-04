using BSMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSInterface
{
    public interface ITimeScheduleRepository
    {
        List<TimeSchedule> GetAll();
        TimeSchedule Get(int id);
        int Insert(TimeSchedule timeSchedule);
       // int Update(TimeSchedule timeSchedule);
        //int Delete(int id);
        List<TimeSchedule> GetAllScehedule();
        int DeleteTimeSchedule(TimeSchedule timeSchedule);
        int UpdateTimeSchedule(TimeSchedule timeSchedule);
    }
}
