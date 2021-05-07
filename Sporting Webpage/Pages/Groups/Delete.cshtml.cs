using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportEU.Data;
using SportEU.Infra;

namespace SportEU.Pages.Groups
{
    public class DeleteModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext _context;

        public DeleteModel(SportEU.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GroupData GroupData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroupData = await _context.Groups.FindAsync(id);

            if (GroupData != null)
            {
                _context.Groups.Remove(GroupData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
