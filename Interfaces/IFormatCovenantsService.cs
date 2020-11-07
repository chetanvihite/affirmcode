using System.Collections.Generic;
using affirmLoans.Business;

namespace affirmLoans.Interfaces
{
    public interface IFormatCovenantsService
    {
        List<FormattedCovenants> FormatCovenants(List<Facility> facilities, List<Covenant> covenants);
    }
}