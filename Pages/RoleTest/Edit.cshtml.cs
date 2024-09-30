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
    public class EditModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public EditModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

         public List<Role> Roles { get; set; }

             [BindProperty]
        public List<int> AssignedRoles { get; set; }

        [BindProperty]
        public TestRole TestRole { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             Roles = _context.Role.OrderBy(x => x.Name).ToList();
            AssignedRoles = new();
            var testrole =  await _context.Test.FirstOrDefaultAsync(m => m.TestId == id);
            var r = _context.TestRole.Where(x => x.TestId == id).Select(x => x.RoleId).ToList();
            for(int i = 0; i < Roles.Count;i++) {
                if (r.Contains(Roles[i].RoleId)) {
                    AssignedRoles.Add(Roles[i].RoleId);
                } else {
                    AssignedRoles.Add(0);
                }
            }
      

            if (testrole == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TestRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestRoleExists(TestRole.TestRoleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TestRoleExists(int id)
        {
            return _context.TestRole.Any(e => e.TestRoleId == id);
        }
    }
}
