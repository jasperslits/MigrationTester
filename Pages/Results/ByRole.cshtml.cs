using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MigrationTester.Data;
using MigrationTester.Models;
using MigrationTester.Models.BL;

namespace MigrationTester.Pages.Results
{
    public class DisplayObj {
        public string TaskName { get; set; }
        public string Action { get; set; }
        public string Role { get; set; }

    }

    public class ByRoleModel : PageModel
    {
        private readonly MigrationTester.Data.MigDbContext _context;

        public ByRoleModel(MigrationTester.Data.MigDbContext context)
        {
            _context = context;
        }

        public TestStatusType TST { get; set; }

        public IList<Result> Result { get;set; } = default!;

        public async Task OnGetAsync(int roleid,int testid)
        {
            Result = await _context.Result
            .Include(y => y.Test)
            .Include(x => x.Gcc)
            .Include(x => x.Test.TestRole)
            .ThenInclude(x => x.Role)
            .Include(y => y.Test.Procedure)
            .Where(x => x.TestId == testid && x.RoleId == roleid).ToListAsync();
        }
    }
}
