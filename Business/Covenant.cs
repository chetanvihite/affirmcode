using CsvHelper.Configuration.Attributes;

namespace affirmLoans.Business
{
    public class Covenant
    {
        [Name("facility_id")]
      public int FacilityId {  
        get;
        set;
      }
        [Name("max_default_likelihood")]
      public float? MaxDefaultLikelihood {  
        get;
        set;
      }
        [Name("bank_id")]
      public int BankId {  
        get;
        set;
      }
        [Name("banned_state")]
      public string BannedState {  
        get;
        set;
      } 
    }
}