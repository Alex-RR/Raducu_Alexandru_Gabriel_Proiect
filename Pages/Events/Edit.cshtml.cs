using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raducu_Alexandru_Gabriel_Proiect.Data;
using Raducu_Alexandru_Gabriel_Proiect.Models;

namespace Raducu_Alexandru_Gabriel_Proiect.Pages.Events
{
    public class EditModel : EventGuestsPageModel
    {
        private readonly Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext _context;

        public EditModel(Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event
                     .Include(b => b.Location)
                     .Include(b => b.EventGuests).ThenInclude(b => b.Guest)
                     .AsNoTracking()
                     .FirstOrDefaultAsync(m => m.ID == id);

            if (Event == null)
            {
                return NotFound();
            }

            PopulateAssignedGuestData(_context, Event);
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGuests)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventToUpdate = await _context.Event
            .Include(i => i.Location)
            .Include(i => i.EventGuests)
            .ThenInclude(i => i.Guest)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (eventToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Event>(
            eventToUpdate,
            "Event",
            i => i.Name, i => i.Description, i => i.FullDateTime, i => i.EventStatus, i => i.Duration, i => i.Location))
            {
                UpdateEventGuests(_context, selectedGuests, eventToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateEventGuests(_context, selectedGuests, eventToUpdate);
            PopulateAssignedGuestData(_context, eventToUpdate);
            return Page();
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.ID == id);
        }
    }
}
