using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raducu_Alexandru_Gabriel_Proiect.Models
{
    public class Location
    {
        public int ID { get; set; }
        [Display(Name = "Location Name")]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }
        [MinLength(3)]
        [Required]
        public string Address { get; set; }
        [MinLength(3)]
        [Required]
        public string City { get; set; }
        [MinLength(3)]
        [Required]
        public string County { get; set; }
        [MinLength(3)]
        [Required]
        public string Country { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
