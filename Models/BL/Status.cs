namespace MigrationTester.Models.BL;

public class Status {
    public int GccId { get; set; }

     public string GccName { get; set; }

    public int TotalTests { get; set; }

    public int CompletedTests { get; set; }

      public int PendingTests { get; set; }

    public int Failedtests { get; set; }

    public int CompletitionPercentage { get; set; }
}

public enum TestStatusType: ushort {
    Success = 1 ,
    Failed = 4,
    NotApplicable = 2,
    New = 3
}

public class Toolbox {

    

    public List<TestStatus> GetTestStatus() {
        return new List<TestStatus>() 
        {
            new TestStatus { Id = 1, Name = "Success" },
            new TestStatus { Id = 2, Name = "Not Applicable" },
            new TestStatus { Id = 3, Name = "New" },
            new TestStatus { Id = 4, Name = "Failed" }
        };
      

    }

}