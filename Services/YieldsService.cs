﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using affirmLoans.Business;
using affirmLoans.Mappers;
using CsvHelper;

namespace affirmLoans.Services
{
    public class YieldsService
    {
        public void WriteYieldsToCSV(List<Yield> yields, string filePath) {
            
            foreach (var yield in yields) {
                yield.ExpectedYield = Math.Round(yield.ExpectedYield);
            }
            
            // write output file
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter( writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<YieldsMap>();
                csv.WriteRecords(yields);
            }
        }
    }
}