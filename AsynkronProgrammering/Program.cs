using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynkronProgrammering
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfStrings = new List<string>
            {
                "Anna", "Bertil", "Cecilia", "David", "Elin", "Fredrik", "Greta", "Håkan", "Ines", "Johan"
            };

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var resultSet = listOfStrings
                .AsParallel() // för att få asynkront i en foreach (allt exekveras samtidigt)
                .Select(ReverseString);

            foreach (string name in resultSet)
            {
                Console.WriteLine(name);
            }
            stopWatch.Stop();

            Console.WriteLine($"{Environment.NewLine}Det tog {stopWatch.ElapsedMilliseconds / 1000.0} sekunder.");
        }

        static string ReverseString(string s)
        {
            Thread.Sleep(1000);
            return new string(s.Reverse().ToArray());

        }
    }
}
