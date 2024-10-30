using ClassLibrary1;
using System;
using System.Linq;

namespace CountrieLinq
{
    internal class Task3
    {
        internal class Subtask1 : IMenuItem
        {
            public string Name => "subtask 1";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var capitalsWithAP = from capital in context.Capitals
                                         where capital.CapitalName.Contains("a") && capital.CapitalName.Contains("p")
                                         select capital.CapitalName;

                    foreach (var capital in capitalsWithAP)
                    {
                        Console.WriteLine($"Столица с 'a' и 'p' в названии: {capital}");
                    }
                }
            }
        }

        internal class Subtask2 : IMenuItem
        {
            public string Name => "subtask 2";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var capitalsStartingWithK = from capital in context.Capitals
                                                where capital.CapitalName.StartsWith("k", StringComparison.OrdinalIgnoreCase)
                                                select capital.CapitalName;

                    foreach (var capital in capitalsStartingWithK)
                    {
                        Console.WriteLine($"Столица, начинающаяся с 'k': {capital}");
                    }
                }
            }
        }

        internal class Subtask3 : IMenuItem
        {
            public string Name => "subtask 3";
            public void Execute()
            {
                Console.WriteLine("Введите минимальную площадь:");
                decimal minArea = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Введите максимальную площадь:");
                decimal maxArea = decimal.Parse(Console.ReadLine());
                Console.Clear();

                using (var context = new DataClasses1DataContext())
                {
                    var countriesInAreaRange = from country in context.Countries
                                               where country.Area >= minArea && country.Area <= maxArea
                                               select country.CountryName;

                    foreach (var country in countriesInAreaRange)
                    {
                        Console.WriteLine($"Страна с площадью в диапазоне: {country}");
                    }
                }
            }
        }

        internal class Subtask4 : IMenuItem
        {
            public string Name => "subtask 4";
            public void Execute()
            {
                Console.WriteLine("Введите минимальное количество жителей:");
                if (int.TryParse(Console.ReadLine(), out int populationThreshold))
                {
                    Console.Clear();
                    using (var context = new DataClasses1DataContext())
                    {
                        var countriesWithLargePopulation = from country in context.Countries
                                                           where country.Population > populationThreshold
                                                           select country.CountryName;

                        foreach (var country in countriesWithLargePopulation)
                        {
                            Console.WriteLine($"Страна с населением больше {populationThreshold}: {country}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Некорректное значение населения.");
                }
            }
        }
    }
}
