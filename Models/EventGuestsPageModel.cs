using Microsoft.AspNetCore.Mvc.RazorPages;
using Raducu_Alexandru_Gabriel_Proiect.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raducu_Alexandru_Gabriel_Proiect.Models
{
    public class EventGuestsPageModel : PageModel
    {
        public List<AssignedGuestData> AssignedGuestDataList;
        public void PopulateAssignedGuestData(Raducu_Alexandru_Gabriel_ProiectContext context,
        Event currentEvent)
        {
            var allGuests = context.Guest;
            var currentEventGuests = new HashSet<int>(
            currentEvent.EventGuests.Select(c => c.GuestID));
            AssignedGuestDataList = new List<AssignedGuestData>();
            foreach (var gst in allGuests)
            {
                AssignedGuestDataList.Add(new AssignedGuestData
                {
                    GuestID = gst.ID,
                    Name = gst.Name,
                    Assigned = currentEventGuests.Contains(gst.ID)
                });
            }
        }
        public void UpdateEventGuests(Raducu_Alexandru_Gabriel_ProiectContext context, string[] selectedGuests, Event eventToUpdate)
        {
            Console.WriteLine(selectedGuests);
            if (selectedGuests == null)
            {
                eventToUpdate.EventGuests = new List<EventGuest>();
                return;
            }
            var selectedGuestsHS = new HashSet<string>(selectedGuests);
            var currentEventGuests = new HashSet<int>(eventToUpdate.EventGuests.Select(c => c.Guest.ID));
            foreach (var gst in context.Guest)
            {
                if (selectedGuestsHS.Contains(gst.ID.ToString()))
                {
                    if (!currentEventGuests.Contains(gst.ID))
                    {
                        eventToUpdate.EventGuests.Add(
                        new EventGuest
                        {
                            EventID = eventToUpdate.ID,
                            GuestID = gst.ID
                        });
                    }
                }
                else
                {
                    if (currentEventGuests.Contains(gst.ID))
                    {
                        EventGuest courseToRemove = eventToUpdate
                        .EventGuests
                        .SingleOrDefault(i => i.GuestID == gst.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
