using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MigrationTester.Pages;
using MigrationTester.Data;
using MigrationTester.Models.BL;
using MigrationTester.Models;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly MigDbContext _context;



    public IndexModel(ILogger<IndexModel> logger, MigDbContext context)
    {
        _logger = logger;
        _context = context;
    }

  public List<Status> Statuses { get; set; }

    public void OnGet()
    {
    Statuses = new();
    Toolbox t = new();
    
    var tests = _context.Test.ToList();
    var gccs = _context.Gcc.Where(x => x.GccId > 1).ToList();
    var result = _context.Result.ToList();
    foreach(var gcc in gccs) {
      Statuses.Add(new Status {
        GccId = gcc.GccId,
        GccName = gcc.Name,
        TotalTests = result.Where(z => z.Gcc == gcc || z.GccId == 0).Count(),
        CompletedTests = result.Where( z => z.GccId == gcc.GccId && z.TestStatus == (int)TestStatusType.Success).Count(),
        Failedtests = result.Where( z => z.GccId == gcc.GccId && z.TestStatus == (int)TestStatusType.Failed).Count(),

      });
    }
    Statuses.ForEach(z => z.CompletitionPercentage = (int)Math.Round(((double)z.CompletedTests / z.TotalTests)*100));
    Statuses.ForEach(z => z.PendingTests = z.TotalTests - z.CompletedTests);
    }
}
