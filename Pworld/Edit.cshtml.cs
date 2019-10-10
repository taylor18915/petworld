using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pet_World.Data;

namespace Pet_World.Pages.Pworld
{
    public class EditModel : PageModel
    {
        private readonly Pet_World.Data.ApplicationDbContext _context;

        public EditModel(Pet_World.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PetStores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetStoresExists(PetStores.PID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PetStoresExists(string id)
        {
            return _context.PetStores.Any(e => e.PID == id);
        }
    }
}
