using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace day08
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<string> instructions = new List<string>();
            
            foreach(string action in File.ReadLines("input.txt"))
            {
                instructions.Add(action);
            }
             
            foreach(string inst in instructions)
            {
                Console.Write(inst + " ::: ");
            }
            Console.WriteLine();

            int result1 = SolvePart1(instructions);

            Console.WriteLine($"Part1 Result = {result1}");
        }

        static int SolvePart1(List<string> actions)
        {
            HashSet<int> instAddress = new HashSet<int>();
            int accumulatorValue = 0;
            int address = 0;
            Console.WriteLine("BEGIN");
            while(address<1000)
            {
                Console.Write(actions[address] + " - ");
                string[] completeAction = actions[address].Split(' ');
                int offset = Int32.Parse(completeAction[1]);
                string action = completeAction[0].Trim();

                switch(action)
                {
                    case "nop":
                        address ++;
                        if(!instAddress.Add(address))
                        {
                            return accumulatorValue;
                        }
                        break;
                    case "acc":
                        address ++;
                        if(!instAddress.Add(address))
                        {
                            return accumulatorValue;
                        }
                        accumulatorValue += offset;  
                        break;
                    case "jmp":
                        address += offset;
                        if(!instAddress.Add(address))
                        {
                            return accumulatorValue;
                        }
                        break;
                }
            }
            Console.WriteLine();
            return accumulatorValue;


        }
    }
}
