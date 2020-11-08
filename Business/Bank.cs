using CsvHelper.Configuration.Attributes;

namespace affirmLoans.Business
{
    public class Bank
    {
        [Name("id")]
      public int Id {  
        get;  
        set;  
      }
        [Name("name")]
      public string Name {  
        get;  
        set;  
      }        
    }
}