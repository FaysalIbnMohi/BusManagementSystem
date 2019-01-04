using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSEntity
{
    public class Transport: Entity
    {
        public int Id { get; set; }
        public string TransportNo { get; set; }
        public Guid TransPortId { get; set; }
        public Guid DriverId { get; set; }
        public Guid HelperId { get; set; }
        public Guid SupervisorId { get; set; }
        public string Route { get; set; }
        [Required]
        public int SeatCapacity { get; set; }
        public bool IsActive { get; set; }


        [NotMapped]
        public string Name { get; set; }
        
    }
}
