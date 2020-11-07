using System.Collections.Generic;

namespace affirmLoans.Business
{
    public class FormattedCovenants
    {
        public int FacilityId
        {
            get;
            set;
        }
        public float? MaxDefaultLikelihood
        {
            get;
            set;
        }
        public int BankId
        {
            get;
            set;
        }
        public List<string> BannedStates
        {
            get;
            set;
        }
    }
}