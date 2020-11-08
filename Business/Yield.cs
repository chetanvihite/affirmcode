using CsvHelper.Configuration.Attributes;

namespace affirmLoans.Business
{
    public class Yield
    {
        [Name("facility_id")]
      public int FacilityId {  
        get;
        set;
      }
        [Name("expected_yield")]
      public double ExpectedYield {  
        get;
        set;
      }
    }
}
