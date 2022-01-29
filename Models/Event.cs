using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raducu_Alexandru_Gabriel_Proiect.Models
{
    public class Event
    {
        public int ID { get; set; }
        [Display(Name = "Event Name")]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }
        [MinLength(10)]
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date and Time")]
        [Required]
        public DateTime FullDateTime { get; set; }

        [Display(Name = "Event Status")]
        [Required]
        public string EventStatus { get; set; }
        [Display(Name = "Duration")]
        [RegularExpression(@"^[0-9]*h([0-9]*m)?$", ErrorMessage = "Duration format is (hours)h(minutes)m (ex: 1h20m), minutes are optional (ex: 1h)")]
        [Required]
        public string Duration { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
        [Display(Name = "Guest List")]
        public ICollection<EventGuest> EventGuests { get; set; }

    }
}
