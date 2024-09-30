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
    public class IndexModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public IndexModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public IList<Result> Result { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Result = await _context.Result.Include(x => x.Gcc).Include(y => y.Test).ToListAsync();
        }
    }
}
