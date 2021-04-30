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

namespace SportEU.Pages.Groups
{
    public class EditModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext _context;

        public EditModel(SportEU.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GroupData GroupData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroupData = await _context.Groups.FirstOrDefaultAsync(m => m.Id == id);

            if (GroupData == null)
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

            _context.Attach(GroupData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupDataExists(GroupData.Id))
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

        private bool GroupDataExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
