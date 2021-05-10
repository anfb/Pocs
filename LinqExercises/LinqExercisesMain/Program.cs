using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercisesMain
{
    class Program
    {
        /*https://www.w3resource.com/csharp-exercises/linq/index.php*/
        public static void Main(string[] args)
        {
            int[] arrayInt = new int[100];
            for (int i = 0; i < arrayInt.Length; i++)
            {
                arrayInt[i] = i;
            }

            //Q1
            Console.WriteLine($"Q1: {string.Join(" - ", arrayInt.Where(i => i%2 == 0))}");

            //Q2
            Console.WriteLine($"Q2: {string.Join(" - ", arrayInt.Where(i => i%2 == 1 && i<=11))}");

            //Q3
            var exampleObjectDynamic = arrayInt.Select(i => new { Number = i, Sqrt = Math.Pow(i,2)});
            foreach (var item in exampleObjectDynamic)
            {
                Console.WriteLine($"Number = {item.Number}, SqrNo = {item.Sqrt}");
            }

            IEnumerable<Square> exampleWithClass = arrayInt.Select(i => new Square(){ Number = i, Sqrt = Math.Pow(i, 2) });
            foreach (var item in exampleWithClass)
            {
                Console.WriteLine($"{item.Number}, {item.Sqrt}");
            }

            //Q4
            IEnumerable<int> arrayQ4 = new List<int>()
            {
                5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6
            };
            IEnumerable<IGrouping<int, int>> resultQ4 = arrayQ4.GroupBy(i => i);
            foreach (var item in resultQ4)
            {
                Console.WriteLine($"Number = {item.Key}, appears {item.Count()} times");
            }

            //Q5
            string name = "Juliette";
            IEnumerable<IGrouping<char, char>> groupingByChair = name.Replace(" ", string.Empty).ToCharArray().GroupBy(c => c);
            foreach (var item in groupingByChair)
            {
                Console.WriteLine($"Character {item.Key}: {item.Count()} times");
            }

            //Q6
            IEnumerable<DateTime> dateDimeList = new List<DateTime>()
            {
                DateTime.Now.AddDays(-2),
                DateTime.Now.AddDays(-1),
                DateTime.Now,
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2)
            };
            Console.WriteLine($"Q6: {string.Join(", ", dateDimeList.Select(d => d.DayOfWeek))}");

            //Q7
            IEnumerable<MultiplicationClass> multiplicationList = arrayQ4.GroupBy(i => i).Select(i => new MultiplicationClass() { Number = i.Key, Qtd = i.Count()});
            foreach (var item in multiplicationList)
            {
                Console.WriteLine($"{item.Number} - {item.Multiplication} - {item.Qtd}");
            }

            //Q8
            IEnumerable<string> cities = new List<string>()
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

            char starts = 'c';
            char end = 'a';
            var cityResult = cities.Where(i => i.StartsWith(starts.ToString()) && i.EndsWith(end.ToString()));
            Console.WriteLine(", ", cityResult.ToString());
        }
    }

    class Square 
    {
        public int Number { get; set; }
        public double Sqrt { get; set; }
    }

    class MultiplicationClass
    {
        public int Number { get; set; }
        public int Qtd { get; set; }
        public int Multiplication { get { return Number * Qtd;} }
    }
}
