using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using SportEU.Infra;

namespace SportEU.Pages.Coaches
{
    public class EditModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext _context;

        public EditModel(SportEU.Infra.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CoachData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachDataExists(CoachData.Id))
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

        private bool CoachDataExists(int id)
        {
            return _context.Coaches.Any(e => e.Id == id);
        }
    }
}
