using CsvHelper.Configuration.Attributes;

namespace affirmLoans.Business
{
    public class Facility
    {
        [Name("id")]
        public int Id {  
            get;
            set;
        }
        [Name("amount")]
        public decimal Amount {  
            get;
            set;
        }
        [Ignore]
        public decimal AvailableFunds
        {
            get;
            set;
        }
        [Name("interest_rate")]
        public float InterestRate {  
            get;
            set;
        }
        [Name("bank_id")]
        public int BankId {  
            get;
            set;
        }

    }
}
