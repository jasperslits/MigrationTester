using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MigrationTester.Pages;
using MigrationTester.Data;
using MigrationTester.Models.BL;
using MigrationTester.Models;
using Microsoft.EntityFrameworkCore;

public class SeedModel : PageModel
{
    private readonly ILogger<SeedModel> _logger;

    private readonly MigDbContext _context;

   private List<TestStatus> R { get; set; }

    public SeedModel(ILogger<SeedModel> logger, MigDbContext context)
    {
        _logger = logger;
        _context = context;
    }

  public Dictionary<string, int> SeedResults { get; set; } = new();


  public async Task OnGet(string gcc)
  {
    List<Module> modules = new List<Module>() {
      new Module { ModuleId = 1, Name = "Exchange"},
      new Module { ModuleId = 2, Name = "People"},
    };

    List<Category> categories = new List<Category>() { 
      new Category { Name = "Data quality actions", ModuleId = 1, CategoryId = 1 },
     new Category { Name = "Payroll process actions", ModuleId = 1, CategoryId = 2 },
    new Category { Name = "Configuration", ModuleId = 1, CategoryId = 3 },
    };

    List<Role> roles = new List<Role>() {
      new Role { Name = "Auditor",RoleId=1},
      new Role { Name = "HR", RoleId=2},
      new Role { Name = "Data management", RoleId=3},
      new Role { Name = "LE Approver",RoleId=4},
      new Role { Name = "PMA",RoleId=5},
      new Role { Name = "Payroll manager vendor",RoleId=6},
      new Role { Name = "Data control",RoleId=7},
      new Role { Name = "IT Onboarding",RoleId=8},
      new Role { Name = "IT Regular",RoleId=9},
      new Role { Name = "SR",RoleId=10},
      new Role { Name = "Data migration",RoleId=11},
    };

    List<Gcc> gccs = new List<Gcc>() {
      new Gcc { Name = "ALL",Code="ALL",GccId = 1},
        new Gcc { Name = "AKN",Code = "AKN",GccId = 2},
         new Gcc { Name = "FrieslandCampina",Code = "FCA", GccId = 3},
        new Gcc { Name = "Marriott",Code = "MRT",GccId = 4}
    };


        List<Procedure> procedures = new List<Procedure>() { 
      new Procedure { Name = "Data entry", ProcedureId = 1, CategoryId = 1 },
     new Procedure { Name = "Error management", ProcedureId = 2, CategoryId = 1 },
    new Procedure { Name = "Hire / term data", ProcedureId = 3, CategoryId = 1 },
    new Procedure { Name = "Status:waiting", ProcedureId = 4, CategoryId = 1 },
    new Procedure { Name = "Integration management", ProcedureId = 5, CategoryId = 1 },
     new Procedure { Name = "Calendar management", ProcedureId = 6, CategoryId = 2 },
      new Procedure { Name = "Legal entity approval", ProcedureId = 7, CategoryId = 2 },
      new Procedure { Name = "Document management", ProcedureId = 8, CategoryId = 2 },
       new Procedure { Name = "Not applicable", ProcedureId = 9, CategoryId = 3 },
    };

    List<Test> tests = new List<Test>() {
      new Test { Name = "Some test",ProcedureId = 1, GccId = 1, TestId =1, TaskName = "Forms", Action = "Create" }
    };


    await _context.Module.ExecuteDeleteAsync();
    await _context.Category.ExecuteDeleteAsync();
    await _context.Role.ExecuteDeleteAsync();
    await _context.Procedures.ExecuteDeleteAsync();
    await _context.Gcc.ExecuteDeleteAsync();
     await _context.Result.ExecuteDeleteAsync();
    await _context.Test.ExecuteDeleteAsync();
    int r;
    _context.Module.AddRange(modules);
    r = _context.SaveChanges();
    SeedResults.Add("Module", r); 

     _context.Category.AddRange(categories);
     r = _context.SaveChanges();
     SeedResults.Add("Category", r); 

    _context.Gcc.AddRange(gccs);
     r = _context.SaveChanges();
     SeedResults.Add("GCC", r); 

     _context.Role.AddRange(roles);
     r = _context.SaveChanges();
     SeedResults.Add("Roles", r); 

     _context.Procedures.AddRange(procedures);
     r = _context.SaveChanges();
     SeedResults.Add("Procedures", r);

    _context.Test.AddRange(tests);
    r = _context.SaveChanges();
     SeedResults.Add("Tests", r);

    List<Result> results = new(); 

    foreach (var test in tests) {
      foreach(var x in gccs) {
        if (x.GccId > 1) {
          results.Add(new Result { GccId = x.GccId, TestId = test.TestId, TestStatus = (int)TestStatusType.New });
        }
      }
      
    }

     _context.Result.AddRange(results);
    r = _context.SaveChanges();
     SeedResults.Add("Results", r);

  }



}
