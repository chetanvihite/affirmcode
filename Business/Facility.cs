namespace affirmLoans.Business
{
    public class Facility
    {
        public int Id {  
            get;
            set;
        }  
        public decimal Amount {  
            get;
            set;
        }
        public decimal AvailableFunds
        {
            get;
            set;
        }
        public float InterestRate {  
            get;
            set;
        }
        public int BankId {  
            get;
            set;
        }

    }
}
