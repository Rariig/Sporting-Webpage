﻿using System;
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
        private readonly SportEU.Infra.ApplicationDbContext _context;

        public DetailsModel(SportEU.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        public GroupData GroupData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroupData = await _context.Groups
                .Include(g => g.Coach).FirstOrDefaultAsync(m => m.Id == id);

            if (GroupData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
