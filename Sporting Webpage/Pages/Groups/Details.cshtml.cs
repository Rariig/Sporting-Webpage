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
    public class DetailsModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext db;

        public DetailsModel(SportEU.Infra.ApplicationDbContext context)
        {
            db = context;
        }

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
    }
}
