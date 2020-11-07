

using affirmLoans.Business;
using CsvHelper.Configuration;

namespace affirmLoans.Mappers
{

    public sealed class BanksMap : ClassMap<Bank>
    {

        public BanksMap()
        {
            Map(x => x.Id).Name("id");
            Map(x => x.Name).Name("name");
        }
    }
}

