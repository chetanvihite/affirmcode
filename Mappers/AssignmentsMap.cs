

using affirmLoans.Business;
using CsvHelper.Configuration;

namespace affirmLoans.Mappers {  

  public sealed class AssignmentsMap: ClassMap < Assignment> {  

    public AssignmentsMap() {  
      Map(x => x.LoanId).Name("loan_id");
      Map(x => x.FacilityId).Name("facility_id");
    }
  }
}
