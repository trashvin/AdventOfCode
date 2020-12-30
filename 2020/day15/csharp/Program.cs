using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace day15
{
    class Program
    {
        static int[] test1 = {0,3,6}; //436
        static int[] test2 = {1,3,2}; //1
        static int[] test3 = {2,1,3}; //10
        static int[] input={15,5,1,4,7,0};
        static int whatNumber = 2020;
        static long whatLongNumber = 30000000;
        static Dictionary<long, long> lastRecords = new Dictionary<long, long>();
        static Dictionary<long, long> previousRecords = new Dictionary<long, long>();
        static void Main(string[] args)
        {
            // int result1 = SolvePart1(input);
            // Console.WriteLine($"Part1 Result = {result1}");

            long result2 = SolvePart2(input);
            Console.WriteLine($"Part2 Result = {result2}");
        }

        static int SolvePart1(int[] series)
        {
            int current =0;
            int step = 0;
            int lastNumber = 0;
            
            List<int> numbers = new List<int>();
            numbers.AddRange(series);
            //step = series.Length;
            lastNumber = numbers[series.Length-1];


            foreach(int n in numbers)
            {
                //Console.Write($"{step}:{n}   ");
                step++;
            }

            while(step <whatNumber)
            {
                
                var occurrences = Enumerable.Range
                                    (0,
                                    numbers.ToArray().Length)
                                    .Where( i => numbers.ToArray()[i]== lastNumber)
                                    .ToArray();
                
                if (occurrences.Length <= 1)
                {
                    lastNumber = 0;
                    numbers.Add(0);
                }
                else if(occurrences.Length > 1)
                {
                    lastNumber = occurrences[occurrences.Length-1] 
                                    - occurrences[occurrences.Length-2];
                    numbers.Add(lastNumber);
                }
                // Console.Write($"{step}:{lastNumber}   ");
                // if (step % 5  == 0 && step >series.Length) Console.WriteLine();
                current = step;
                step ++;
            }

            return lastNumber;
        }
        static long SolvePart2(int[] series)
        {
            //long current =0;
            long step = 0;
            long lastNumber = 0;
            
            lastRecords.Clear();
            previousRecords.Clear();
            List<long> numbers = new List<long>();

            for(int y=0; y<series.Length; y++)
            {
                numbers.Add((long)series[y]);
                step++;

                Store((long)series[y], (long) step);
                Console.WriteLine($"{step} : {series[y]}");
            }
            
            //step = series.Length;
            lastNumber = numbers[series.Length-1];

            while(step <whatLongNumber)
            {
                
                if (HasOccured(lastNumber))
                {
                    var tupLoc = GetLast(lastNumber);

                    if (tupLoc.Item2 >= 0)
                    {
                        lastNumber = Math.Abs(tupLoc.Item1 - tupLoc.Item2);
                        Store(lastNumber, step+1, true);
                    }
                    else
                    {
                        lastNumber = 0;
                        Store(lastNumber, step+1,true);
                    }
                }
                else
                {
                    lastNumber = 0;
                    Store(lastNumber, step);
                }

                if (step < 10) Console.WriteLine($"{step} : {lastNumber}");
                //Console.Write($"{step} -  ");
                if (step % 10000 == 0 ) 
                {
                    Console.WriteLine(step);
                    //Console.ReadKey();
                }
                step ++;
            }

            return lastNumber;
        }

        static void Store(long number, long steps, bool addPrev = false)
        {
            long temp = -1;
            if (lastRecords.ContainsKey(number)) 
            {
                temp = lastRecords[number];
                lastRecords[number] = steps;
            }
            else lastRecords.Add(number,steps);

            if (addPrev)
            {
                if (previousRecords.ContainsKey(number)) previousRecords[number] = temp;
                else previousRecords.Add(number, temp);
            }
            
        }

        static bool HasOccured(long number)
        {
            return lastRecords.ContainsKey(number);
        }

        static (long, long) GetLast(long number)
        {
            long last = -1;
            long prev = -1;
            if (lastRecords.ContainsKey(number)) last = lastRecords[number];
            if (previousRecords.ContainsKey(number)) prev = previousRecords[number];

            return (last, prev);
        }
    
    }
}
