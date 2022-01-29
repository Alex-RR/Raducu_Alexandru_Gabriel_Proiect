using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raducu_Alexandru_Gabriel_Proiect.Data;
using Raducu_Alexandru_Gabriel_Proiect.Models;

namespace Raducu_Alexandru_Gabriel_Proiect.Pages.Guests
{
    public class DetailsModel : PageModel
    {
        private readonly Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext _context;

        public DetailsModel(Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext context)
        {
            _context = context;
        }

        public Guest Guest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Guest = await _context.Guest.FirstOrDefaultAsync(m => m.ID == id);

            if (Guest == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
