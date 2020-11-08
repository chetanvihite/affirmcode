using CsvHelper.Configuration.Attributes;

namespace affirmLoans.Business
{
    public class Loan
    {
        [Name("interest_rate")]
      public float InterestRate {  
        get;
        set;
      }
        [Name("amount")]
      public long Amount {  
        get;
        set;
      }
        [Name("id")]
      public int Id {  
        get;
        set;
      }
        [Name("default_likelihood")]
      public float DefaultLikelyhood {  
        get;
        set;
      }
        [Name("state")]
      public string State {  
        get;
        set;
      } 
    }
}
