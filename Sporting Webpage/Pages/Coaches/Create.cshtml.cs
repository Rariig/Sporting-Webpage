﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data;
using SportEU.Infra;

namespace SportEU.Pages.Coaches
{
    public class CreateModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext _context;

        public CreateModel(SportEU.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CoachData CoachData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Coaches.Add(CoachData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
