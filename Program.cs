using System;
using System.Collections.Generic;
using System.Linq;

namespace LotteryApp2
{
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Bool to determine application life cycle
            bool endApp = false;

            // App life cycle
            while (!endApp)
            {
                Console.WriteLine("How many cycles do you want this to run for?");

                List<int> results = new List<int>();
                List<int> specials = new List<int>();

                int result = Int32.Parse(Console.ReadLine());
                Random rnd = new Random();

                for (int i = 0; i < result; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        results.Add(rnd.Next(1, 50));
                    }

                    for (int j = 0; j < 2; j++)
                    {
                        specials.Add(rnd.Next(1, 12));
                    }
                }


                Console.WriteLine("Here are all the main ball lottery picks that have been chosen:");

                // Prints out all the picks -> This does impact performance when outputting large data set
                for (int i = 0; i < results.Count(); i++)
                {

                    if ((i == 0) || (i % 5 != 0))
                    {
                        Console.Write(results[i] + " | ");
                    }
                    else
                    {

                        Console.Write("\n" + results[i] + " | ");

                    }
                }
                Console.Write("\n");
                Console.WriteLine("Here are all the special ball lottery picks that have been chosen:");

                for (int y = 0; y < specials.Count; y++)
                {
                    if (y == 0) Console.Write(specials[y] + " | ");
                    else
                    {
                        if (y % 2 != 0)
                            Console.Write(specials[y] + " | ");
                        else
                            Console.Write("\n" + specials[y] + " | ");
                    }
                }
                Console.Write("\n");

                var newList = results.GroupBy(x => x).OrderByDescending(x => x.Count()).SelectMany(x => x).ToList();
                newList = newList.Select(x => x).Distinct().ToList();

                var speList = specials.GroupBy(x => x).OrderByDescending(x => x.Count()).SelectMany(x => x).ToList();
                speList = speList.Select(x => x).Distinct().ToList();

                Console.WriteLine("For your best chance of winning. I would suggest these numbers here as they have appeared the most.");

                for (int i = 0; i < 5; i++)
                {
                    Console.Write(newList[i] + " | ");
                }

                for (int i = 0; i < 2; i++)
                {
                    Console.Write(speList[i] + " | ");

                }

                Console.Write("\n");
                Console.WriteLine("Do you want to continue?");

                if (Console.ReadLine() == "no")
                {
                    endApp = true;
                }
                else
                {
                    Console.WriteLine("Good, lets continue");
                }
            }
        }
    }
}
