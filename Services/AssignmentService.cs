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
    public class AssignmentService
    {
        public void WriteAssignmentsToCSV(List<Assignment> assignments, string filePath)
        {          

            // write output file
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(assignments);
            }
        }
    }
}
