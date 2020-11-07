

using affirmLoans.Business;
using CsvHelper.Configuration;

namespace affirmLoans.Mappers
{

    public sealed class FacilitiesMap : ClassMap<Facility>
    {

        public FacilitiesMap()
        {
            Map(x => x.Amount).Name("amount");
            Map(x => x.InterestRate).Name("interest_rate");
            Map(x => x.Id).Name("id");
            Map(x => x.BankId).Name("bank_id");
        }
    }
}
