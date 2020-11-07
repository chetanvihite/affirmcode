

using affirmLoans.Business;
using CsvHelper.Configuration;

namespace affirmLoans.Mappers
{

    public sealed class LoansMap : ClassMap<Loan>
    {

        public LoansMap()
        {
            Map(x => x.InterestRate).Name("interest_rate");
            Map(x => x.Amount).Name("amount");
            Map(x => x.Id).Name("id");
            Map(x => x.DefaultLikelyhood).Name("default_likelihood");
            Map(x => x.State).Name("state");
        }
    }
}
