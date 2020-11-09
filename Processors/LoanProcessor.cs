using System.Collections.Generic;
using System.Linq;
using affirmLoans.Business;
using affirmLoans.Interfaces;
using affirmLoans.Services;

namespace affirmLoans.Processors
{
    public class LoanProcessor
    {
        private List<Facility> facilities = null;
        private List<Bank> banks = null;
        
        private List<FormattedCovenants> formattedCovenants = new List<FormattedCovenants>();
        private List<Assignment> loanAssignments = new List<Assignment>();
        private List<Yield> yields = new List<Yield>();
        private IFormatCovenantsService formatCovenants = new FormatCovenantsService();
        private CovenantService covenantService = new CovenantService();

        public LoanProcessor(List<Facility> facilities, List<Bank> banks, List<Covenant> covenants)
        {
            this.facilities = facilities;
            this.banks = banks;

            // build formatted covanants            
            formattedCovenants = formatCovenants.FormatCovenants(facilities, covenants);

            //build yields
            yields = (from facility in facilities
                     select new Yield()
                     {
                         FacilityId = facility.Id
                     }).ToList();
        }

        // loans should be proceesed in ordered "Loans are ordered chronologically by loan id"
        public ProcessOutput ProcessLoans(List<Loan> loans) {            

            var orderedLoans = loans.OrderBy(l => l.Id);

            // get facilities ordered by interest rate
            var orderedFacilities = facilities.OrderBy(f => f.InterestRate);

            // loop thru' ordered list by id
            foreach (var loan in orderedLoans) {

                // assign loans one by one to facility that fulfills the requirements.
                // itegrate thru facilities in the ordered seq of low interest rate
                foreach (var facility in orderedFacilities)
                {
                    if (facility.AvailableFunds == 0) {
                        facility.AvailableFunds = facility.Amount;
                    }
                    // get covenants
                    var facilityCovenants = formattedCovenants.Where(c => c.FacilityId == facility.Id).FirstOrDefault();
                                        
                    var covenantsRuleStatus = covenantService.CheckCovenants(facilityCovenants, loan);
                    // make sure loan is not originating from banned state and max default likelihood is less
                    //if (!facilityCovenants.BannedStates.Contains(loan.State) && loan.DefaultLikelyhood <= facilityCovenants.MaxDefaultLikelihood )
                    if ( covenantsRuleStatus == true) //if it passes all the covenants
                    {
                        // calculate yield for this facility
                        var expectedYield = (1 - loan.DefaultLikelyhood) * loan.InterestRate * loan.Amount
                            - loan.DefaultLikelyhood * loan.Amount - facility.InterestRate * loan.Amount;

                        // then make sure we have funds at this facility and expected Yield is nonnegative
                        if ( (loan.Amount < facility.AvailableFunds) && expectedYield > 0 ) {
                            // ready to fund
                            var assignment = new Assignment
                            {
                                LoanId = loan.Id,
                                FacilityId = facility.Id
                            };

                            loanAssignments.Add(assignment);

                            // deduct from available funds
                            facility.AvailableFunds -= loan.Amount;


                            var yieldRecord = yields.FirstOrDefault(y => y.FacilityId == facility.Id);
                            if (yieldRecord != null) {
                                yieldRecord.ExpectedYield += expectedYield;
                            }

                            break; // move to next loan
                        }
                    }
                }

            } //end-process-assign-loans
            
            return new ProcessOutput() {
                Assignments = loanAssignments,
                Yields = yields
            };
        }

    }
}
