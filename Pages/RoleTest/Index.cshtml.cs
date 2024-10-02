using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MigrationTester.Data;
using MigrationTester.Models;

namespace MigrationTester.Pages.RoleTest
{
    public class IndexModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public IndexModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public IList<TestRole> TestRole { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TestRole = await _context.TestRole.Include(x => x.Test).ThenInclude(x => x.Procedure).Include(x => x.Role).ToListAsync();
        }
    }
}
