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
             
            // foreach(string inst in instructions)
            // {
            //     Console.Write(inst + " ::: ");
            // }
            //Console.WriteLine();

            int result1 = SolvePart1(instructions);

            Console.WriteLine($"Part1 Result = {result1}");

            int result2 = SolvePart2(instructions);

            Console.WriteLine($"Part2 Result = {result2}");

        }

        static int SolvePart1(List<string> actions)
        {
            HashSet<int> instAddress = new HashSet<int>();
            int accumulatorValue = 0;
            int address = 0;
            while(address<1000)
            {
                //Console.Write(actions[address] + " - ");
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
            //Console.WriteLine();
            return accumulatorValue;
        }

        static int SolvePart2(List<string> actions)
        {        
            int accumulatorValue = 0;
            int address = 0;
            string temp=String.Empty;

            for(int x = 0; x<actions.Count; x++)
            {
                HashSet<int> instAddress = new HashSet<int>();
                List<string> changingActions = new List<string>();
                changingActions.AddRange(actions);
                
                if (changingActions[x].StartsWith("jmp") )
                {
                    temp = changingActions[x];
                    changingActions[x] = changingActions[x].Replace("jmp","nop");
                }
                else if (changingActions[x].StartsWith("nop") )
                {
                    temp = changingActions[x];
                    changingActions[x] = changingActions[x].Replace("nop","jmp");
                }
      
                accumulatorValue = 0;
                address = 0;
                bool conflict = false;
                bool exit = false;
                while(address<10000)
                {
                    Console.Write(changingActions[address]);
                    string[] completeAction = changingActions[address].Split(' ');
                    int offset = Int32.Parse(completeAction[1]);
                    string action = completeAction[0].Trim();
                   
                    switch(action)
                    {
                        case "nop":
                            address ++;
                            if(!instAddress.Add(address))
                            {
                                conflict = true;
                                exit = true;
                            }
                            if (address >= changingActions.Count)
                            {
                                conflict=false;
                                exit=true;
                            }
                            break;
                        case "acc":
                            address ++;
                            if(!instAddress.Add(address))
                            {
                                conflict = true;
                                exit = true;
                            }
                            accumulatorValue += offset;  
                            if (address >= changingActions.Count)
                            {
                                conflict=false;
                                exit=true;
                            }
                            break;
                        case "jmp":
                            address += offset;
                            if(!instAddress.Add(address))
                            {
                                conflict = true;
                                exit = true;
                            }
                            if (address >= changingActions.Count)
                            {
                                conflict=false;
                                exit=true;
                            }
                            break;
                    }
                    if(exit) break;
                }
                
                if(!conflict)  break;
            }
            return accumulatorValue;
        }
    }
}
