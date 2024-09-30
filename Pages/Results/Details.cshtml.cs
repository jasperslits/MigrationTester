using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MigrationTester.Data;
using MigrationTester.Models;

namespace MigrationTester.Pages.Results
{
    public class DetailsModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public DetailsModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public Result Result { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Result.FirstOrDefaultAsync(m => m.ResultId == id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                Result = result;
            }
            return Page();
        }
    }
}
