using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace day09
{
    class Program
    {
        const int PREAMBLE = 25;
        static void Main(string[] args)
        {
            List<long> codes = new List<long>();

            //get the numbers
            foreach(string code in File.ReadLines("input.txt"))
            {
                codes.Add(Int64.Parse(code));
            }
            //sanity check
            // Console.WriteLine(codes[codes.Count-1]);

            long result1 = SolvePart1(codes);
            Console.WriteLine($"Part1 result = {result1}");

            long result2 = SolvePart2(codes, result1);
            Console.WriteLine($"Part2 result = {result2}");
        }

        static long SolvePart1(List<long> codes)
        {
            int startPreamble = 0;
            int endPreamble = 0;
            //PrintList(codes);
            //Console.WriteLine("---");
            bool valid = false;
            long numberToCheck=0;
            while(endPreamble< codes.Count - 2)
            {
                valid = false;
                endPreamble = startPreamble + PREAMBLE;
                startPreamble ++;
                long[] preambles = codes.Skip(startPreamble).Take(PREAMBLE).ToArray();        
                numberToCheck =  codes[endPreamble + 1];

                //PrintList(preambles.ToList());
                //Console.WriteLine(numberToCheck.ToString());
                for(int outerLoop = 0 ; outerLoop< preambles.Length; outerLoop ++)
                {
                    long number1 = preambles[outerLoop];
                    for(int innerLoop = 0; innerLoop < preambles.Length; innerLoop++)
                    {
                        if ( innerLoop != outerLoop)
                        {
                            long number2 = preambles[innerLoop];
                            long sum = number1 + number2;
                            if(sum == numberToCheck)
                            {
                                //Console.WriteLine($"{numberToCheck} = {sum}");
                                valid = true;
                                break;
                            }
                        }           
                    }
                    if (valid) break;
                }

                if (!valid) break;
            }

            if (valid) return 0;
            else return numberToCheck;
        }

        static long SolvePart2(List<long> codes, long breakingNumber)
        {
            //int startSeries = 0;
            bool found = false;
            long min = 0;
            long max = 0;
            for(int start = 0; start < codes.Count; start++)
            {
                long accumulatedSum = codes[start];

                min = codes[start];
                max = codes[start];

                for(int inner = start+1; inner < codes.Count; inner++)
                {
                    accumulatedSum += codes[inner];

                    if(codes[inner]<min) min = codes[inner];
                    if(codes[inner]>max) max = codes[inner];

                    if (accumulatedSum == breakingNumber)
                    {
                        // Console.WriteLine(accumulatedSum);
                        found = true;
                        break;
                    }
                    if(accumulatedSum > breakingNumber)
                    {
                        found = false;
                        break;
                    }
                }

                if (found) break;
            }

            return min + max;
        }

        static void PrintList(List<long> codes)
        {
            foreach(long i in codes)
            {
                Console.Write(i.ToString() + " , ");
            }
            Console.WriteLine();
        }
    }
}
