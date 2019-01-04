using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMSEntity
{
    public class Employee : Entity
    {
        [Required, Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Email { get; set; }
        public string PresentAddress { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string UserRole { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string PermanentAddress { get; set; }
        [Required(ErrorMessage = "This Field is Required"), MaxLength(14), MinLength(11)]
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
