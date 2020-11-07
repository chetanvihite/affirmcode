using System;
using affirmLoans.Processors;
using affirmLoans.Services;

namespace affirmLoans
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = "/Users/cvihite/projects/samples/affirm-coding/affirmLoans/Assets/small";

            var facilities = new FacilityService().GetFacilities($"{basePath}/facilities.csv");
            var banks = new BankService().GetBanks($"{basePath}/banks.csv");
            var covenants = new CovenantsService().GetCovenants($"{basePath}/covenants.csv");
            var loans = new LoanService().GetLoans($"{basePath}/loans.csv");

            var loanProcessor = new LoanProcessor(facilities, banks, covenants);
            var processOutput = loanProcessor.ProcessLoans(loans);

            var dateFormat = DateTime.Now.ToString("s");

            var assignmentsFilePath = $"{basePath}/assignment__{dateFormat}_.csv";
            var yieldsFilePath = $"{basePath}/yields__{dateFormat}_.csv";

            YieldsService yieldsService = new YieldsService();
            yieldsService.WriteYieldsToCSV(processOutput.Yields, yieldsFilePath);

            AssignmentService assignmentService = new AssignmentService();
            assignmentService.WriteAssignmentsToCSV(processOutput.Assignments, assignmentsFilePath);

            Console.WriteLine(" end of loan assignment process... ");
        }
    }
}
