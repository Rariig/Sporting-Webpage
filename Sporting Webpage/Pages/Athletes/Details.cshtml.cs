using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using SportEU.Infra;

namespace SportEU.Pages.Athletes
{
    public class DetailsModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext _context;

        public DetailsModel(SportEU.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        public AthleteData AthleteData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AthleteData = await _context.Athletes.FirstOrDefaultAsync(m => m.Id == id);

            if (AthleteData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
