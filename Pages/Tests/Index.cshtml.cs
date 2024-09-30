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
    public class IndexModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public IndexModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public IList<Test> Test { get;set; } = default!;

        public async Task OnGetAsync(int? procedureId)
        {
            if (procedureId == null) {
            Test = await _context.Test
                .Include(t => t.Procedure).Include(x => x.Procedure.Category).ToListAsync();
            } else {
                 Test = await _context.Test
                .Include(t => t.Procedure).Include(x => x.Procedure.Category).Where(x => x.ProcedureId == procedureId).ToListAsync();
            }
        }
    }
}
