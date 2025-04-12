using System;
using System.Diagnostics;
using System.Linq;
namespace AirportSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2 || !int.TryParse(args[1], out int columnIndex) || columnIndex < 1)
            {
                Console.WriteLine("Использование: AirportSearcher <путь_к_файлу> <номер_колонки>");
                return;
            }

            try
            {
                var service = new AirportSearchService();
                service.Initialize(args[0], columnIndex - 1);

                while (true)
                {
                    Console.WriteLine("Введите текст для поиска (для выхода введите '!quit'):");
                    var query = Console.ReadLine();

                    if (query == "!quit")
                    {
                        Console.WriteLine("Программа завершена.");
                        break;
                    }

                    var stopwatch = Stopwatch.StartNew();
                    var results = service.Search(query).ToList();
                    stopwatch.Stop();

                    if (results.Count == 0)
                    {
                        Console.WriteLine("Ничего не найдено.");
                    }
                    else
                    {
                        foreach (var (key, line) in results)
                        {
                            Console.WriteLine($"{key}[{line}]");
                        }
                    }

                    Console.WriteLine($"Найдено строк: {results.Count}");
                    Console.WriteLine($"Время поиска: {stopwatch.ElapsedMilliseconds} мс");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}