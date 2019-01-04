using BSMSEntity;
using BSMSInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSRepository
{

    public class TimeScheduleRepository : Repository<TimeSchedule>, ITimeScheduleRepository
    {
        DataContext context = new DataContext();
        public int DeleteTimeSchedule(TimeSchedule timeSchedule)
        {
            TimeSchedule timeScheduleUpdate = context.TimeSchedules.SingleOrDefault(e => e.Id == timeSchedule.Id);
            timeScheduleUpdate.IsActive = false;
            return context.SaveChanges();
        }

        public TimeSchedule Get(int id)
        {
            return context.TimeSchedules.Where(e => e.Id == id).SingleOrDefault();
        }

        public List<TimeSchedule> GetAll()
        {
            return context.TimeSchedules.ToList();
        }

        public int Insert(TimeSchedule timeSchedule)
        {
            context.TimeSchedules.Add(timeSchedule);
            return context.SaveChanges();
        }

        public int UpdateTimeSchedule(TimeSchedule timeSchedule)
        {
            TimeSchedule timeScheduleUpdate = context.TimeSchedules.SingleOrDefault(e => e.Id == timeSchedule.Id);
            timeScheduleUpdate.StartTime = timeSchedule.StartTime;
            timeScheduleUpdate.DepartureTime = timeSchedule.DepartureTime;
            timeScheduleUpdate.UserId = timeSchedule.UserId;
            timeScheduleUpdate.TransportId = timeSchedule.TransportId;
            timeScheduleUpdate.IsActive = timeSchedule.IsActive;
            return context.SaveChanges();
        }

        public List<TimeSchedule> GetAllScehedule()
        {
            string ConnectionString = "server=.\\SQLEXPRESS; database=BSMSDB; integrated security=true";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            List<TimeSchedule> tschedule = new List<TimeSchedule>();
                string SqlQuery = @"select es.FirstName, es.LastName, T.TransportNo,TS.Id, TS.IsActive, TS.StartTime, TS.DepartureTime  from TimeSchedules as TS left Join Employees as es on TS.UserId = es.UserId left join Transports as T on T.TransPortId = TS.TransportId";

            SqlCommand cmd = new SqlCommand(SqlQuery);
            cmd.Connection = con;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TimeSchedule t = new TimeSchedule();
                t.StartTime = rdr["StartTime"].ToString();
                t.DepartureTime = rdr["DepartureTime"].ToString();
                t.Name = rdr["FirstName"].ToString() + rdr["LastName"].ToString();
                t.TransportNo = rdr["TransportNo"].ToString();
                t.IsActive = Convert.ToBoolean(rdr["IsActive"]);
                t.Id = Convert.ToInt32(rdr["Id"]);
                tschedule.Add(t);
            }
            con.Close();
            return tschedule;
        }

        
    }
}
