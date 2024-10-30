using ClassLibrary1; 
using System;
using System.Linq;

namespace CountrieLinq
{
    internal class Task4
    {
        internal class Subtask1 : IMenuItem
        {
            public string Name => "subtask 1";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var top5CountriesByArea = context.Countries
                                                      .OrderByDescending(c => c.Area)
                                                      .Take(5)
                                                      .Select(c => new { c.CountryName, c.Area });

                    foreach (var country in top5CountriesByArea)
                    {
                        Console.WriteLine($"Страна: {country.CountryName}, Площадь: {country.Area}");
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
                    var top5CapitalsByPopulation = context.Capitals
                                                           .OrderByDescending(c => c.CapitalPopulation)
                                                           .Take(5)
                                                           .Select(c => new { c.CapitalName, c.CapitalPopulation });

                    foreach (var capital in top5CapitalsByPopulation)
                    {
                        Console.WriteLine($"Столица: {capital.CapitalName}, Население: {capital.CapitalPopulation}");
                    }
                }
            }
        }

        internal class Subtask3 : IMenuItem
        {
            public string Name => "subtask 3";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var largestCountry = context.Countries
                                                .OrderByDescending(c => c.Area)
                                                .FirstOrDefault();

                    if (largestCountry != null)
                    {
                        Console.WriteLine($"Страна с самой большой площадью: {largestCountry.CountryName}, Площадь: {largestCountry.Area}");
                    }
                }
            }
        }

        internal class Subtask4 : IMenuItem
        {
            public string Name => "subtask 4";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var largestCapital = context.Capitals
                                                 .OrderByDescending(c => c.CapitalPopulation)
                                                 .FirstOrDefault();

                    if (largestCapital != null)
                    {
                        Console.WriteLine($"Столица с самым большим количеством жителей: {largestCapital.CapitalName}, Население: {largestCapital.CapitalPopulation}");
                    }
                }
            }
        }

        internal class Subtask5 : IMenuItem
        {
            public string Name => "subtask 5";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var smallestCountryInEurope = context.Countries
                                                         .Where(c => c.Continent == "Европа")
                                                         .OrderBy(c => c.Area)
                                                         .FirstOrDefault();

                    if (smallestCountryInEurope != null)
                    {
                        Console.WriteLine($"Страна с самой маленькой площадью в Европе: {smallestCountryInEurope.CountryName}, Площадь: {smallestCountryInEurope.Area}");
                    }
                }
            }
        }

        internal class Subtask6 : IMenuItem 
        {
            public string Name => "subtask 6";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var averageAreaInEurope = context.Countries
                                                       .Where(c => c.Continent == "Европа")
                                                       .Average(c => c.Area);

                    Console.WriteLine($"Средняя площадь стран в Европе: {averageAreaInEurope}");
                }
            }
        }

        internal class Subtask7 : IMenuItem 
        {
            public string Name => "subtask 7";
            public void Execute()
            {
                Console.WriteLine("Введите название страны:");
                string countryName = Console.ReadLine();
                Console.Clear();
                using (var context = new DataClasses1DataContext())
                {
                    var top3CitiesByPopulation = context.Cities
                                                         .Where(city => city.Countries.CountryName == countryName)
                                                         .OrderByDescending(city => city.CityPopulation)
                                                         .Take(3)
                                                         .Select(city => new { city.CityName, city.CityPopulation });

                    foreach (var city in top3CitiesByPopulation)
                    {
                        Console.WriteLine($"Город: {city.CityName}, Население: {city.CityPopulation}");
                    }
                }
            }
        }

        internal class Subtask8 : IMenuItem
        {
            public string Name => "subtask 8";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var totalCountries = context.Countries.Count();
                    Console.WriteLine($"Общее количество стран: {totalCountries}");
                }
            }
        }

        internal class Subtask9 : IMenuItem 
        {
            public string Name => "subtask 9";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var continentWithMaxCountries = context.Countries
                                                           .GroupBy(c => c.Continent)
                                                           .OrderByDescending(g => g.Count())
                                                           .Select(g => new { Continent = g.Key, Count = g.Count() })
                                                           .FirstOrDefault();

                    if (continentWithMaxCountries != null)
                    {
                        Console.WriteLine($"Часть света с максимальным количеством стран: {continentWithMaxCountries.Continent}, Количество стран: {continentWithMaxCountries.Count}");
                    }
                }
            }
        }

        internal class Subtask10 : IMenuItem 
        {
            public string Name => "subtask 10";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var countriesCountByContinent = context.Countries
                                                           .GroupBy(c => c.Continent)
                                                           .Select(g => new { Continent = g.Key, Count = g.Count() });

                    foreach (var continent in countriesCountByContinent)
                    {
                        Console.WriteLine($"Часть света: {continent.Continent}, Количество стран: {continent.Count}");
                    }
                }
            }
        }
    }
}
