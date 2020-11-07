

using affirmLoans.Business;
using CsvHelper.Configuration;

namespace affirmLoans.Mappers
{

    public sealed class YieldsMap : ClassMap<Yield>
    {

        public YieldsMap()
        {
            Map(x => x.FacilityId).Name("facility_id");
            Map(x => x.ExpectedYield).Name("expected_yield");
        }
    }
}
