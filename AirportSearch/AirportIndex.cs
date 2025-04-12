using System;
using System.Collections.Generic;
using System.IO;

namespace AirportSearch
{
    class AirportIndex
    {
        private readonly SortedDictionary<string, List<string>> index = new SortedDictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public void BuildIndex(string filePath, int columnIndex)
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var airport = new Airport(line);
                    if (airport.Columns.Length > columnIndex)
                    {
                        var key = airport.Columns[columnIndex].Trim('"');
                        if (!index.ContainsKey(key))
                        {
                            index[key] = new List<string>();
                        }
                        index[key].Add(line);
                    }
                }
            }
        }

        public IEnumerable<(string Key, string Line)> Search(string query)
        {
            query = query.Trim().ToLowerInvariant();
            foreach (var key in index.Keys)
            {
                if (key.ToLowerInvariant().StartsWith(query))
                {
                    foreach (var line in index[key])
                    {
                        yield return (key, line);
                    }
                }
            }
        }
    }
}
