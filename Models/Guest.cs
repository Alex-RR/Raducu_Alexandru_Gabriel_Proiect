using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raducu_Alexandru_Gabriel_Proiect.Models
{
    public class Guest
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Please add both first name and last name of the guest")]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"(.+)@(.+){2,}\.(.+){2,}", ErrorMessage = "Please enter a valid email address")]
        [MinLength(3)]
        [Required]
        public string Email { get; set; }
        public ICollection<EventGuest> EventGuests { get; set; }
    }
}
