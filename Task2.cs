using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrieLinq
{
    internal class Task2
    {
        internal class Subtask1 : IMenuItem
        {
            public string Name => "subtask 1";
            public void Execute()
            {
                using (var context = new DataClasses1DataContext())
                {
                    var countriesInfo = from country in context.Countries
                                        select new
                                        {
                                            CountryName = country.CountryName,
                                            Area = country.Area,
                                            Population = country.Population,
                                            Continent = country.Continent
                                        };

                    foreach (var country in countriesInfo)
                    {
                        Console.WriteLine($"Страна: {country.CountryName}, Площадь: {country.Area}, Население: {country.Population}, Часть света: {country.Continent}");
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
                    var countryNames = context.Countries.Select(c => c.CountryName);

                    foreach (var name in countryNames)
                    {
                        Console.WriteLine($"Страна: {name}");
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
                    var capitalNames = context.Capitals.Select(c => c.CapitalName);

                    foreach (var name in capitalNames)
                    {
                        Console.WriteLine($"Столица: {name}");
                    }
                }
            }
        }

        internal class Subtask4 : IMenuItem
        {
            public string Name => "subtask 4";
            public void Execute()
            {
                Console.WriteLine("Введите нужное название страны");
                string countryName = Console.ReadLine();
                Console.Clear();
                using (var context = new DataClasses1DataContext())
                {
                    var majorCities = from city in context.Cities
                                      join country in context.Countries on city.CountryId equals country.Id
                                      where country.CountryName == countryName
                                      select city.CityName;

                    foreach (var city in majorCities)
                    {
                        Console.WriteLine($"Крупный город: {city}");
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
                    var capitalsWithLargePopulation = from capital in context.Capitals
                                                      where capital.CapitalPopulation > 5000000
                                                      select capital.CapitalName;

                    foreach (var capital in capitalsWithLargePopulation)
                    {
                        Console.WriteLine($"Столица с населением больше 5 миллионов: {capital}");
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
                    var europeanCountries = from country in context.Countries
                                            where country.Continent == "Европа"
                                            select country.CountryName;

                    foreach (var country in europeanCountries)
                    {
                        Console.WriteLine($"Европейская страна: {country}");
                    }
                }
            }
        }

        internal class Subtask7 : IMenuItem
        {
            public string Name => "subtask 7";
            public void Execute()
            {
                Console.WriteLine("Введите значение площади:");
                if (decimal.TryParse(Console.ReadLine(), out decimal areaThreshold))
                {
                    Console.Clear();
                    using (var context = new DataClasses1DataContext())
                    {
                        var largeCountries = from country in context.Countries
                                             where country.Area > areaThreshold
                                             select country.CountryName;

                        foreach (var country in largeCountries)
                        {
                            Console.WriteLine($"Страна с площадью больше {areaThreshold}: {country}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Некорректное значение площади.");
                }
            }
        }
    }
}
