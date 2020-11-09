using System;
using System.Collections.Generic;
using affirmLoans.Business;
using affirmLoans.Services;

namespace affirmLoans.Services
{
    public class CovenantService
    {
        private List<ICovenantRules> covenantRules = new List<ICovenantRules>();
        public CovenantService()
        {
            covenantRules.Add(new CovenantBannedStateRule());
            covenantRules.Add(new CovenantMaxLikelihoodRule());
        }
        // execute covenant rules one by one
        // *** this allows for future extensibility. ***

        public bool CheckCovenants(FormattedCovenants covenants, Loan loan ) 
        {
            var ruleStatus = true;
            foreach (var rule in covenantRules)
            {
                // if any of the rule is not fulfilled, loan can not be assigned to current facility
                var currentRuleResult = rule.CheckRule(covenants, loan);
                if (currentRuleResult == false)
                {
                    ruleStatus = false;
                    break;
                }
            }
            return ruleStatus;
        }
    }
}


public class CovenantBannedStateRule : ICovenantRules
{
    // make sure the loan state is not in banned state
    public bool CheckRule(FormattedCovenants covenants, Loan loan)
    {
        return !(covenants.BannedStates.Contains(loan.State));
    }
}

public class CovenantMaxLikelihoodRule : ICovenantRules
{
    // make sure the loan's default likelihood is less than facility's
    public bool CheckRule(FormattedCovenants covenants, Loan loan)
    {
        return (loan.DefaultLikelyhood <= covenants.MaxDefaultLikelihood);
    }
}