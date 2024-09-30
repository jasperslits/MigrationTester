using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MigrationTester.Pages;
using MigrationTester.Data;
using MigrationTester.Models.BL;
using MigrationTester.Models;
using Microsoft.EntityFrameworkCore;

public class GccDetailsModel : PageModel
{
    private readonly ILogger<GccDetailsModel> _logger;

    private readonly MigDbContext _context;

   private List<TestStatus> R { get; set; }

    public GccDetailsModel(ILogger<GccDetailsModel> logger, MigDbContext context)
    {
        _logger = logger;
        _context = context;
    Toolbox t = new();
    R = t.GetTestStatus();
    }

    public Gcc Gcc { get; set; }

  public List<Result> TestDetails { get; set; }

  public string StatusToName(int s) {
    return ((TestStatusType)s).ToString();
   // return s.ToString();
  }

  public void OnGet(int gcc,string type)
  {
      Gcc = _context.Gcc.Where(x => x.GccId == gcc).FirstOrDefault();
      TestDetails  = _context.Result.Include(x => x.Test).ThenInclude(z => z.Procedure).ThenInclude(a => a.Category).Where(x => x.GccId == gcc).ToList();
      if (type == "pending") {
        TestDetails = TestDetails.Where(x => x.TestStatus == (int)TestStatusType.New).ToList();
      } 
       if (type == "failed") {
        TestDetails = TestDetails.Where(x => x.TestStatus == (int)TestStatusType.Failed).ToList();
      }
      if (type == "completed") {
        TestDetails = TestDetails.Where(x => x.TestStatus == (int)TestStatusType.Success).ToList();
      }
      

  }

}
