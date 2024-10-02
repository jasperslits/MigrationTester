namespace MigrationTester.Models;

using System.ComponentModel.DataAnnotations;

public class TestStatus {
    public int Id { get; set; }
    public string Name { get; set; }

}

public class Module {

    public int ModuleId {get;set;}
    public string Name {get;set;}

}

public class Procedure {
    public int ProcedureId { get; set; }
    public string Name { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}



public class Role {

    public int RoleId { get; set;}

    public string Name { get; set;}
}



public class Gcc {

    [Key]
    public int GccId { get; set; }
    public string Code { get; set;}

    public string Name { get; set;}
}

public class Test {

    public int TestId { get; set;}

    public string Name { get; set;}

    public string TaskName { get; set;}

    public string Action { get; set;}

    [Display(Name = "GCC")]
    public int GccId { get; set;}
    
    public Gcc Gcc { get; set;}

    [Display(Name = "Category")]
    public int ProcedureId { get; set;}
    public Procedure Procedure { get; set; } 

    public List<TestRole> TestRole { get; set; }
}

public class Result {

    public int ResultId { get; set;}

    [Display(Name = "GCC")]
    public int GccId { get; set; }

    public Gcc Gcc { get; set;}

 [Display(Name = "Tested on")]
    public DateTime ModifiedOn { get; set; }

    public string Comments { get; set; }

     [Display(Name = "Ticket nr")]
    public string Ticketnr { get; set; }

    public string Tester { get; set; }

    [Display(Name = "Status")]
    public int TestStatus { get; set; }

    public int TestId { get; set; }

    public Test Test { get; set; }

    [Display(Name = "Role")]
    public int RoleId { get; set; }

    public Role Role{ get; set; }
}

public class Category {

    public int CategoryId { get; set;}

    public string Name { get; set;}

    public int ModuleId { get; set; }
    public Module Module { get; set; }
}

public class TestRole {
    public int TestRoleId { get; set;}
    public int RoleId { get; set;}

    public int TestId { get; set; }

    public Role Role  { get; set; }
    public Test Test  { get; set; }
}