using System.Collections.Generic;

namespace AirportSearch
{
    class Airport
    {
        public string[] Columns { get; }

        public Airport(string line)
        {
            Columns = ParseCsvLine(line);
        }

        private static string[] ParseCsvLine(string line)
        {
            var result = new List<string>();
            var current = "";
            var inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (line[i] == ',' && !inQuotes)
                {
                    result.Add(current);
                    current = "";
                }
                else
                {
                    current += line[i];
                }
            }

            result.Add(current);
            return result.ToArray();
        }
    }
}
