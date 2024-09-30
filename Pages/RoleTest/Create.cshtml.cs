using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MigrationTester.Data;
using MigrationTester.Models;

namespace MigrationTester.Pages.RoleTest
{
    public class CreateModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public CreateModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<int> AssignedRoles { get; set; }
        public List<Role> Roles { get; set; }
        public IActionResult OnGet(int? id)
        {
            Roles = _context.Role.OrderBy(x => x.Name).ToList();

            return Page();
        }

        [BindProperty]
        public TestRole TestRole { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
          //  _context.TestRole.Where(x => x.TestId == TestRole.TestId);
            List<TestRole> rt = new(); 
            foreach(var r in AssignedRoles) {
                rt.Add(new TestRole { RoleId = r, TestId = TestRole.TestId });
            }
            _context.TestRole.AddRange(rt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
