using CsvHelper.Configuration.Attributes;

namespace affirmLoans.Business
{
    public class Assignment
    {
      [Name("loan_id")]
      public int LoanId {  
        get;  
        set;  
      }
        [Name("facility_id")]
        public int FacilityId {  
            get;  
            set;  
        }
        
    }
}