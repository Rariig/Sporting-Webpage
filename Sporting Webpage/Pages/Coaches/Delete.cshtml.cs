using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using SportEU.Infra;

namespace SportEU.Pages.Coaches
{
    public class DeleteModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext _context;

        public DeleteModel(SportEU.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoachData CoachData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoachData = await _context.Coaches.FirstOrDefaultAsync(m => m.Id == id);

            if (CoachData == null)
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

            CoachData = await _context.Coaches.FindAsync(id);

            if (CoachData != null)
            {
                _context.Coaches.Remove(CoachData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
