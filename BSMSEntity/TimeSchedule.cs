using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSEntity
{
    public class TimeSchedule: Entity
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string DepartureTime { get; set; }
        public Guid UserId { get; set; }
        public Guid TransportId { get; set; }
        public bool IsActive { get; set; }

        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public string TransportNo { get; set; }
    }

}
