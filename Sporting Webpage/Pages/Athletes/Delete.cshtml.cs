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
    public class DeleteModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext _context;

        public DeleteModel(SportEU.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AthleteData AthleteData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AthleteData = await _context.Athletes.FindAsync(id);

            if (AthleteData != null)
            {
                _context.Athletes.Remove(AthleteData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
