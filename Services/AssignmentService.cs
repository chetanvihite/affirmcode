

using System.Collections.Generic;
using affirmLoans.Business;
using affirmLoans.Interfaces;
using affirmLoans.Utils;

namespace affirmLoans.Services
{
    public class AssignmentService
    {
        
        public void WriteAssignmentsToCSV(List<Assignment> assignments, string filePath)
        {
            ICSVWrapper<Assignment> csvHelper = new CSVWrapper<Assignment>();
            csvHelper.WriteToCSV(assignments, filePath);

        }
    }
}
