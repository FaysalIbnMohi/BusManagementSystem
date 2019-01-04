using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSEntity
{
   public class Passenger: Entity
    {
        [Key]
        public int Id { get; set; }
        public Guid PassengerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
