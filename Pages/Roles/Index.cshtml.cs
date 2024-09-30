using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MigrationTester.Data;
using MigrationTester.Models;

namespace MigrationTester.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public IndexModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public IList<Role> Role { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Role = await _context.Role.ToListAsync();
        }
    }
}
