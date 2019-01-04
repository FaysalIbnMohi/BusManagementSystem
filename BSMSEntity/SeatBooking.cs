using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSEntity
{
    public class SeatBooking: Entity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string SeatNo { get; set; }
        public Guid TransportId { get; set; } 
        public Guid PassengerId { get; set; }
        public DateTime BookTime { get; set; }
        public Guid BookedBy { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public bool IsCancel { get; set; }
        public string SeatType { get; set; }

    }
}
