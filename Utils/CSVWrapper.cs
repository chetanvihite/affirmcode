using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using affirmLoans.Interfaces;

namespace affirmLoans.Utils
{
    public class CSVWrapper<T> : ICSVWrapper<T> where T : class
    {
        public List<T> ReadCSV(string filePath)
        {
            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.Default))
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<T>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                // log exception, raise exception and handle "gracefully"
                throw new Exception("error occured reading csv file", e); ;
            }
        }

        public void WriteToCSV(List<T> records, string filePath)
        {
            // write output file
            try
            {
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }
            }
            catch (Exception e)
            {
                // log exception, raise exception and handle gracefully
                throw new Exception("error occured writing csv file", e);
            }
            
        }
    }
}
