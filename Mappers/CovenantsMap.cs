

using affirmLoans.Business;
using CsvHelper.Configuration;

namespace affirmLoans.Mappers
{

    public sealed class CovenantsMap : ClassMap<Covenant>
    {

        public CovenantsMap()
        {
            Map(x => x.FacilityId).Name("facility_id");
            Map(x => x.MaxDefaultLikelihood).Name("max_default_likelihood");
            Map(x => x.BankId).Name("bank_id");
            Map(x => x.BannedState).Name("banned_state");
        }
    }
}
