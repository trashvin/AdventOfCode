using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> adapters = new List<int>();

            //get the numbers
            foreach(string adapter in File.ReadLines("test.txt"))
            {
                adapters.Add(Int32.Parse(adapter));
            }

            //sanity check
            Console.WriteLine(adapters[adapters.Count-1]);

            // long result1 = SolvePart1(adapters);
            // Console.WriteLine($"Part1 result = {result1}");

            long result2 = SolvePart2(adapters);
            Console.WriteLine($"Part2 result = {result2}");
        }

        static int SolvePart1(List<int> origAdapters)
        {
            List<int> adapters = new List<int>();
            adapters.AddRange(origAdapters);
            adapters.Add(0);
            adapters.Sort();
            PrintList(adapters);
            int by1 = 0;
            int by3 = 1;
            for(int i = 0 ; i < adapters.Count-1; i++)
            {
                //Console.Write($"{adapters[i]} ; {adapters[i+1]}");
                if (adapters[i+1] - adapters[i] == 1)
                {
                    //Console.WriteLine(" b1");
                    by1++;
                }
                else
                {
                    //Console.WriteLine(" b3");
                    by3++;
                }
            }
            //Console.WriteLine($"By1 {by1} ; By3 {by3}");
            return by1*by3;
        }

        static int SolvePart2(List<int> origAdapters)
        {
            List<int> adapters = new List<int>();
            adapters.AddRange(origAdapters);
            adapters.Add(0);
            adapters.Sort();
            PrintList(adapters);
            
            int count = 1; 
            
            int i=0;
            List<int> accumulator = new List<int>();
            int skip = 1;
            while(i<adapters.Count-3)
            {
                var segment = adapters.Skip(skip).Take(3).ToArray();
                for(int inner = 2 ; inner >=0 ; inner--)
                {
                    int diff = segment[inner] - adapters[i];

                    if ( diff <= 3)
                    {
                        i = i + diff;
                        skip += diff;
                        count++;
                        break;
                    }
                }

                
               

            }

            return count;
        }
        static void PrintList(List<int> codes)
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------");
            foreach(int i in codes)
            {
                Console.Write(i.ToString() + " , ");
            }
            Console.WriteLine("");
            Console.WriteLine("----------------------------");
        }
    }
}
