/*
advent of code 2020 day01
title: report repair
*/
using System;
using System.IO;
using helper;
{
    
}

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entries = File.ReadAllLines("input.txt");
            
            ComputePart1(entries);
            ComputePart2(entries);
            
        }

        static void ComputePart2(string[] entries)
        {
            long result = 0;
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            bool exitNow = false;

            for(int loop1 = 0 ; loop1< entries.Length; loop1 ++)
            {
                number1 = Int32.Parse(entries[loop1]);

                for(int loop2 = 0; loop2 < entries.Length; loop2++)
                {
                    if ( loop2 != loop1)
                    {
                        number2 = Int32.Parse(entries[loop2]);       
                    }

                    for(int loop3 = 0; loop3<entries.Length ; loop3++)
                    {
                        if ( loop3 != loop1 && loop3 != loop2)
                        {
                            number3 = Int32.Parse(entries[loop3]);

                            if(number1 + number2 + number3 == 2020)
                            {
                                result = number1 * number2 * number3;
                                exitNow=true;
                                break;
                            }
                        }
                    }

                    if (exitNow) break;
                }
                if (exitNow) break;

            }
            Console.WriteLine($"Number 1 : {number1} ; Number 2 : {number2} ; Number 3 : {number3}" );
            //Console.WriteLine($"Part2 Result ={result}");
            Library.WriteResult(2,result);


        }
        static void ComputePart1(string[] entries)
        {
            int number1 = 0;
            int number2 = 0;
            long result = 0;
            bool exitNow = false;
            for(int outerLoop = 0 ; outerLoop< entries.Length; outerLoop ++)
            {
                number1 = Int32.Parse(entries[outerLoop]);

                for(int innerLoop = 0; innerLoop < entries.Length; innerLoop++)
                {
                    if ( innerLoop != outerLoop)
                    {
                        number2 = Int32.Parse(entries[innerLoop]);
                        int sum = number1 + number2;
                        if(sum == 2020)
                        {
                            Console.WriteLine($"{number1} + {number2} = {sum}");
                            result = number1 * number2;
                            exitNow = true;
                            break;
                        }
                    }
                }

                if (exitNow) break;

            }
            Console.WriteLine($"Number 1 : {number1} ; Number 2 : {number2}" );
            Library.WriteResult(1,result);
            //Console.WriteLine($"Part1 Result ={result}");
        }
    }
}
