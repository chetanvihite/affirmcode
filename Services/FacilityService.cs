using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using affirmLoans.Business;
using affirmLoans.Mappers;
using CsvHelper;

namespace affirmLoans.Services
{
    public class FacilityService
    {
        public List<Facility> GetFacilities(string filePath)
        {
            try
            {
                using (var streamReader = new StreamReader(filePath, Encoding.Default))
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<FacilitiesMap>();
                    var facilities = csv.GetRecords<Facility>().ToList();
                    return facilities;
                }
            }
            catch (Exception e)
            {
                // log exception, raise exception and caller should handle it gracefully
                throw new Exception(e.Message);
            }
        }
    }
}
