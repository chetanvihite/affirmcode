namespace affirmLoans.Business
{
    public class Covenant
    {
      public int FacilityId {  
        get;
        set;
      }  
      public float? MaxDefaultLikelihood {  
        get;
        set;
      }     
      public int BankId {  
        get;
        set;
      }
      public string BannedState {  
        get;
        set;
      } 
    }
}