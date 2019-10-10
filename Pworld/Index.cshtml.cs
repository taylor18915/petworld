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
    public class IndexModel : PageModel
    {
        private readonly Pet_World.Data.ApplicationDbContext _context;

        public IndexModel(Pet_World.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PetStores> PetStores { get;set; }

        public async Task OnGetAsync()
        {
            PetStores = await _context.PetStores.ToListAsync();
        }
    }
}
