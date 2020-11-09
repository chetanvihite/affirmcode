using affirmLoans.Business;

namespace affirmLoans.Services
{
    internal interface ICovenantRules
    {
        bool CheckRule(FormattedCovenants covenants, Loan loan);
    }
}