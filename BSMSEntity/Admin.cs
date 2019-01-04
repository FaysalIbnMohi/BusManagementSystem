using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BSMSEntity
{
    public class Admin : Entity
    {
        [Required,Key]
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PresentAddress { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required, MaxLength(14), MinLength(11)]
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
