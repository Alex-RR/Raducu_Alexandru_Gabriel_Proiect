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
    public class IndexModel : PageModel
    {
        private readonly Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext _context;

        public IndexModel(Raducu_Alexandru_Gabriel_Proiect.Data.Raducu_Alexandru_Gabriel_ProiectContext context)
        {
            _context = context;
        }

        public IList<Guest> Guest { get;set; }

        public async Task OnGetAsync()
        {
            Guest = await _context.Guest.ToListAsync();
        }
    }
}
