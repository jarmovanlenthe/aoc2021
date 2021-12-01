
using System;
using System.Linq;
using Challenges.Days;

namespace Challenges
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rootType = typeof(IDay<string, string>).GetGenericTypeDefinition();
            var days = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(p => p.GetInterfaces().Where(i => i.IsGenericType).Select(i => i.GetGenericTypeDefinition())
                    .Contains(rootType)).ToList();
            days.RemoveAt(0);

            var dayNumbers = days.Where(d => ! d.Name.Contains('`')).Select(d => int.Parse(d.Name[3..])).ToArray();
            var dayToRun = -1;

            Console.WriteLine($"Which day shall we start? [{dayNumbers.Max()}]");

            string? dayInput;
            while (dayToRun == -1)
            {
                dayInput = Console.ReadLine();
                if (string.IsNullOrEmpty(dayInput))
                {
                    dayToRun = dayNumbers.Max();
                }
                else
                {
                    try
                    {
                        dayToRun = int.Parse(dayInput);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect input... Try again...");
                    }

                    if (dayNumbers.Contains(dayToRun))
                    {
                        continue;
                    }

                    Console.WriteLine("That day does not exist yet... Try again...");
                    dayToRun = -1;
                }

            }
            Console.WriteLine($"Running day {dayToRun}...");

            var day = (IStartable) Activator.CreateInstance(days.First(d => d.Name[3..].EndsWith(dayToRun.ToString())));
            day.DayNumber = dayToRun;
            day.Start();
        }
    }
}
