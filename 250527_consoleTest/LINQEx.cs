using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class LINQEx
    {
        static void Main33()
        {
            int[] numbers = [5, 10, 8, 3, 6, 12];

            // Query 형태의 LINQ
            IEnumerable<int> numQuery1 = from num in numbers
                                         where num % 2 == 0
                                         orderby num
                                         select num;

            foreach(int num in numQuery1)
            {
                Console.WriteLine(num);
            }

            // 메서드 형태의 LINQ
            IEnumerable<int> numQuery2 = numbers.Where(num => num % 2 == 0)
                                                .OrderBy(num => num);

            // Class LINQ
            City[] cities = [
                new City("Seoul", 30_000_000),
                new City("Tokyo", 37_833_000),
                new City("Shanghai", 27_100_000)
            ];

            IEnumerable<City> queryMajorCities = from city in cities
                                                 where city.Population >= 30_000_000
                                                 select city;

            IEnumerable<City> queryMajorCities2 = cities.Where(city => (city.Population >= 30_000_000));

            foreach (City city in queryMajorCities)
            {
                Console.WriteLine($"Name: {city.Name}, Population: {city.Population}");
            }
        }

        public class City
        {
            public string Name { get; set; }
            public long Population { get; set; } 

            public City(string name, long population)
            {
                Name = name;
                Population = population;
            }
        }
    }
}
