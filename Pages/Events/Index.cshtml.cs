using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raducu_Alexandru_Gabriel_Proiect.Data;
using Raducu_Alexandru_Gabriel_Proiect.Models;

namespace Raducu_Alexandru_Gabriel_Proiect.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext _context;

        public IndexModel(Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }
        public EventData EventD { get; set; }
        public int EventID { get; set; }
        public int GuestID { get; set; }

        public async Task OnGetAsync(int? id, int? guestID)
        {
            EventD = new EventData();

            EventD.Events = await _context.Event
            .Include(b => b.Location)
            .Include(b => b.EventGuests)
            .ThenInclude(b => b.Guest)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                EventID = id.Value;
                Event currentEvent = EventD.Events
                .Where(i => i.ID == id.Value).Single();
                EventD.Guests = currentEvent.EventGuests.Select(s => s.Guest);
            }
        }
    }
}
