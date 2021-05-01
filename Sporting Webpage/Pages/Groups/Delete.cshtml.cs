using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using SportEU.Infra;

namespace SportEU.Pages.Groups
{
    public class DeleteModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext db;

        public DeleteModel(SportEU.Infra.ApplicationDbContext context)
        {
            db = context;
        }

        [BindProperty]
        public GroupData GroupData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroupData = await db.Groups.FirstOrDefaultAsync(m => m.Id == id);

            if (GroupData == null)
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

            GroupData = await db.Groups.FindAsync(id);

            if (GroupData != null)
            {
                db.Groups.Remove(GroupData);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
