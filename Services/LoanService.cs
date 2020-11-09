using System.Collections.Generic;
using affirmLoans.Business;
using affirmLoans.Interfaces;
using affirmLoans.Utils;

namespace affirmLoans.Services
{
    public class LoanService
    {
        public List<Loan> GetLoans(string filePath)
        {
            ICSVWrapper<Loan> csvWrapper = new CSVWrapper<Loan>();

            var loans = csvWrapper.ReadCSV(filePath);

            return loans;
        }
    }
}
