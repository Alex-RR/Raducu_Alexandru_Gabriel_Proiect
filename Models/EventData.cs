using System.Collections.Generic;

namespace Raducu_Alexandru_Gabriel_Proiect.Models
{
    public class EventData
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
        public IEnumerable<EventGuest> EventGuests { get; set; }
    }
}
