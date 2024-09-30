using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MigrationTester.Data;
using MigrationTester.Models;

namespace MigrationTester.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public CreateModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Module"] = new SelectList(_context.Module, "ModuleId", "Name");
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
