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
using MigrationTester.Models.BL;

namespace MigrationTester.Pages.Results
{
    public class RV {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }

    public class CreateModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public CreateModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public Test Test { get; set; } 

        public IActionResult OnGet(int id)
        {
            Toolbox t = new Toolbox();
          
            ViewData["TestStatus"] = new SelectList(t.GetTestStatus(), "Id", "Name");
            ViewData["Gcc"] = new SelectList(_context.Gcc, "GccId", "Name");
            Result = _context.Result.Include(x => x.Test).Include(x => x.Gcc).Where(x => x.ResultId == id).FirstOrDefault();
            Test = Result.Test;
            var itemList = _context.TestRole.Include(x => x.Role).Where(x => x.TestId == Test.TestId).Select( o =>
    new RV { Name = o.Role.Name, RoleId = o.RoleId}).ToList();
            ViewData["Role"] = new SelectList(itemList, "RoleId", "Name");
            return Page();
        }

        [BindProperty]
        public Result Result { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Result).State = EntityState.Modified;
         
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
