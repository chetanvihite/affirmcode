using System.Collections.Generic;

namespace affirmLoans.Interfaces
{
    public interface ICSVWrapper<T> where T : class
    {
        List<T> ReadCSV(string filePath);
        void WriteToCSV(List<T> records, string filePath);
    }
}