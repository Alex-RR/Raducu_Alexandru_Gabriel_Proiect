namespace Raducu_Alexandru_Gabriel_Proiect.Models
{
    public class EventGuest
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public Event Event { get; set; }
        public int GuestID { get; set; }
        public Guest Guest { get; set; }
    }
}
