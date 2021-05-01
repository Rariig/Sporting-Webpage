using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data;
using SportEU.Infra;

namespace SportEU.Pages.Groups
{
    public class CreateModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext db;

        public CreateModel(SportEU.Infra.ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GroupData GroupData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Groups.Add(GroupData);
            await db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
