using BSMSEntity;
using BSMSInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSRepository
{

    public class TransportRepository : ITransportRepository
    {
        DataContext context = new DataContext();
        public int DeleteTransport(Transport transport)
        {
            Transport transportUpdate = context.Transports.SingleOrDefault(e => e.Id == transport.Id);
            transportUpdate.IsActive = false;
            return context.SaveChanges();
        }

        public Transport Get(int id)
        {
            return context.Transports.Where(e => e.Id == id).SingleOrDefault();
        }

        public List<Transport> GetAll()
        {
            return context.Transports.ToList();
        }

        public int Insert(Transport transport)
        {
            context.Transports.Add(transport);
            return context.SaveChanges();
        }

        public int Update(Transport transport)
        {
            Transport transportUpdate = context.Transports.SingleOrDefault(e => e.Id == transport.Id);
            transportUpdate.TransportNo = transport.TransportNo;
            transportUpdate.Route = transport.Route;
            transportUpdate.IsActive = transport.IsActive;
            transportUpdate.DriverId = transport.DriverId;
           
            return context.SaveChanges();
        }
        public Transport GetByTransportId(Guid TransportId)
        {
            return context.Transports.Where(x => x.TransPortId == TransportId).FirstOrDefault();
        }

        public List<Transport> GetAllTransport()
        {
            string ConnectionString = "server=.\\SQLEXPRESS; database=BSMSDB; integrated security=true";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            List<Transport> transports = new List<Transport>();
            string SqlQuery = @"select E.FirstName, E.LastName, T.SeatCapacity, T.TransportNo, T.Route, T.IsActive, T.Id 
                                from Transports as T INNER JOIN Employees as E on E.UserId = T.DriverId";

            SqlCommand cmd = new SqlCommand(SqlQuery);
            cmd.Connection = con;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Transport t = new Transport();
                t.SeatCapacity = Convert.ToInt32(rdr["SeatCapacity"]);
                t.Route = rdr["Route"].ToString();
                t.Name = rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString();
                t.TransportNo = rdr["TransportNo"].ToString();
                t.IsActive = Convert.ToBoolean(rdr["IsActive"]);
                t.Id = Convert.ToInt32(rdr["Id"]);
                transports.Add(t);
            }
            con.Close();
            return transports;
        }
    }
}
