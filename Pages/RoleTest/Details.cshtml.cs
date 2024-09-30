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
    public class DetailsModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public DetailsModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public List<int> AssignedRoles { get; set; }
        public List<Role> Roles { get; set; }

        public TestRole TestRole { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testrole = await _context.TestRole.FirstOrDefaultAsync(m => m.TestRoleId == id);
            if (testrole == null)
            {
                return NotFound();
            }
            else
            {
                TestRole = testrole;
            }
            return Page();
        }
    }
}
