using System;
using System.Collections.Generic;
using affirmLoans.Business;
using affirmLoans.Interfaces;
using affirmLoans.Utils;

namespace affirmLoans.Services
{
    public class YieldsService
    {
        public void WriteYieldsToCSV(List<Yield> yields, string filePath) {
            
            foreach (var yield in yields) {
                yield.ExpectedYield = Math.Round(yield.ExpectedYield);
            }

            ICSVWrapper<Yield> csvHelper = new CSVWrapper<Yield>();
            csvHelper.WriteToCSV(yields, filePath);
        }
    }
}
