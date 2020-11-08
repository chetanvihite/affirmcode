using System;
using affirmLoans.Processors;
using affirmLoans.Services;

namespace affirmLoans
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1) {
                Console.WriteLine("no base path argument found...");
                return;                
            }

            var basePath = args[0];

            if (string.IsNullOrEmpty(basePath))
            {
                Console.WriteLine("no base path found...");
                return;
            }

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
