﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportEU.Data;
using SportEU.Infra;

namespace SportEU.Pages.Coaches
{
    public class IndexModel : PageModel
    {
        private readonly SportEU.Infra.ApplicationDbContext _context;

        public IndexModel(SportEU.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CoachData> CoachData { get;set; }

        public async Task OnGetAsync()
        {
            CoachData = await _context.Coaches.ToListAsync();
        }
    }
}
