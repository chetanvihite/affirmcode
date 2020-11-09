using System.Collections.Generic;
using affirmLoans.Business;
using affirmLoans.Interfaces;
using affirmLoans.Utils;

namespace affirmLoans.Services
{
    public class FacilityService
    {
        public List<Facility> GetFacilities(string filePath)
        {
            ICSVWrapper<Facility> csvWrapper = new CSVWrapper<Facility>();

            var facilities = csvWrapper.ReadCSV(filePath);

            return facilities;
        }
    }
}
