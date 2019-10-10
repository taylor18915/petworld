using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pet_World.Data;

namespace Pet_World.Pages.Pworld
{
    public class DetailsModel : PageModel
    {
        private readonly Pet_World.Data.ApplicationDbContext _context;

        public DetailsModel(Pet_World.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PetStores PetStores { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PetStores = await _context.PetStores.FirstOrDefaultAsync(m => m.PID == id);

            if (PetStores == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
