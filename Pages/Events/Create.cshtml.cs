using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raducu_Alexandru_Gabriel_Proiect.Data;
using Raducu_Alexandru_Gabriel_Proiect.Models;

namespace Raducu_Alexandru_Gabriel_Proiect.Pages.Events
{
    public class CreateModel : EventGuestsPageModel
    {
        private readonly Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext _context;

        public CreateModel(Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "Name");
            var currentEvent = new Event();
            currentEvent.EventGuests = new List<EventGuest>();
            PopulateAssignedGuestData(_context, currentEvent);
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedGuests)
        {
            var newEvent = new Event();
            if (selectedGuests != null)
            {
                newEvent.EventGuests = new List<EventGuest>();
                foreach (var gst in selectedGuests)
                {
                    var gstToAdd = new EventGuest
                    {
                        GuestID = int.Parse(gst)
                    };
                    newEvent.EventGuests.Add(gstToAdd);
                }
            }
            if (await TryUpdateModelAsync<Event>(
            newEvent,
            "Event",
            i => i.Name, i => i.Description,
            i => i.FullDateTime, i => i.EventStatus, i => i.Duration, i => i.LocationID))
            {
                _context.Event.Add(newEvent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedGuestData(_context, newEvent);
            return Page();
        }
    }
}
