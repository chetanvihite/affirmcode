using System.Collections.Generic;
using affirmLoans.Business;
using affirmLoans.Interfaces;
using affirmLoans.Utils;

namespace affirmLoans.Services
{
    public class BankService
    {
        public List<Bank> GetBanks(string filePath)
        {
            ICSVWrapper<Bank> csvWrapper = new CSVWrapper<Bank>();

            var banks = csvWrapper.ReadCSV(filePath);

            return banks;            
        }
    }
}
