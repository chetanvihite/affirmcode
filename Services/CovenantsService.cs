using System.Collections.Generic;
using affirmLoans.Business;
using affirmLoans.Interfaces;
using affirmLoans.Utils;

namespace affirmLoans.Services
{
    public class CovenantsService
    {
        public List<Covenant> GetCovenants(string filePath)
        {
            ICSVWrapper<Covenant> csvWrapper = new CSVWrapper<Covenant>();

            var covenants = csvWrapper.ReadCSV(filePath);

            return covenants;
        }
    }
}
