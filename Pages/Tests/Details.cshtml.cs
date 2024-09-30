using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MigrationTester.Data;
using MigrationTester.Models;

namespace MigrationTester.Pages.Tests
{
    public class DetailsModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public DetailsModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public Test Test { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test.FirstOrDefaultAsync(m => m.TestId == id);
            if (test == null)
            {
                return NotFound();
            }
            else
            {
                Test = test;
            }
            return Page();
        }
    }
}
