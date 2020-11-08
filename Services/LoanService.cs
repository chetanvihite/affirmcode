using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using affirmLoans.Business;
using CsvHelper;

namespace affirmLoans.Services
{
    public class LoanService
    {
        public List<Loan> GetLoans(string filePath)
        {
            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.Default))
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var loans = csv.GetRecords<Loan>().ToList();
                    return loans;
                }
            }
            catch (Exception e)
            {
                // log exception, raise exception and caller should handle it gracefully
                throw new Exception(e.Message);
            }
        }
    }
}
