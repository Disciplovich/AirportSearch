using System.Collections.Generic;
using System.IO;

namespace AirportSearch
{
    class AirportSearchService
    {
        private readonly AirportIndex index = new AirportIndex();

        public void Initialize(string filePath, int columnIndex)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден.", filePath);
            }

            index.BuildIndex(filePath, columnIndex);
        }

        public IEnumerable<(string Key, string Line)> Search(string query)
        {
            return index.Search(query);
        }
    }
}
