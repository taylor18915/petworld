using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pet_World.Data;

namespace Pet_World.Pages.Pworld
{
    public class CreateModel : PageModel
    {
        private readonly Pet_World.Data.ApplicationDbContext _context;

        public CreateModel(Pet_World.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PetStores PetStores { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PetStores.Add(PetStores);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}