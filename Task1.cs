using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrieLinq
{
    internal class Subtask1 : IMenuItem
    {
        public string Name => "subtask 1";
        public void Execute()
        {
            using (var context = new DataClasses1DataContext())
            {
                var capitalsPopulation = from country in context.Countries
                                         join capital in context.Capitals on country.Id equals capital.CountryId
                                         select new
                                         {
                                             CountryName = country.CountryName,
                                             CapitalName = capital.CapitalName,
                                             CapitalPopulation = capital.CapitalPopulation
                                         };

                foreach (var item in capitalsPopulation)
                {
                    Console.WriteLine($"Страна: {item.CountryName}, Столица: {item.CapitalName}, Население столицы: {item.CapitalPopulation}");
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
                var citiesPopulation = from country in context.Countries
                                       join city in context.Cities on country.Id equals city.CountryId
                                       select new
                                       {
                                           CountryName = country.CountryName,
                                           CityName = city.CityName,
                                           CityPopulation = city.CityPopulation
                                       };

                foreach (var item in citiesPopulation)
                {
                    Console.WriteLine($"Страна: {item.CountryName}, Город: {item.CityName}, Население: {item.CityPopulation}");
                }
            }
        }
    }
}
