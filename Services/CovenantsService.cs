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
    public class CovenantsService
    {
        public List<Covenant> GetCovenants(string filePath)
        {
            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.Default))
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var covenants = csv.GetRecords<Covenant>().ToList();
                    return covenants;
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
