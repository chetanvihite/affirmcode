
using System;
using System.Collections.Generic;
using System.Linq;
using affirmLoans.Business;
using affirmLoans.Interfaces;

namespace affirmLoans.Services
{
    public class FormatCovenantsService : IFormatCovenantsService
    {
        public List<FormattedCovenants> FormatCovenants(List<Facility> facilities, List<Covenant> covenants)
        {
            List<FormattedCovenants> formattedCovenants = new List<FormattedCovenants>();
            foreach (var facility in facilities)
            {
                var formattedCovant = new FormattedCovenants();
                var rules = covenants.Where(c => c.FacilityId == facility.Id);
                formattedCovant.BannedStates = new List<string>();

                foreach (var rule in rules)
                {
                    formattedCovant.BankId = facility.BankId;
                    formattedCovant.FacilityId = facility.Id;
                    if (rule.MaxDefaultLikelihood != null)
                    {
                        formattedCovant.MaxDefaultLikelihood = rule.MaxDefaultLikelihood;
                    }
                    formattedCovant.BannedStates.Add(rule.BannedState);
                }
                formattedCovenants.Add(formattedCovant);
            }
            return formattedCovenants;
        }
    }
}
