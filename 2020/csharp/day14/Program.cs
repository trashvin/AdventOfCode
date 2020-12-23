using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace day14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DockProgram> programs = new List<DockProgram>();

            string mask = String.Empty;
            List<KeyValuePair<long, long>> memList = new List<KeyValuePair<long, long>>();
            DockProgram program;
            foreach(string line in File.ReadLines("input.txt"))
            {     
                if (line.StartsWith("mask"))
                {
                    //Console.WriteLine("------");

                    if (mask.Length>0)
                    {
                        program = new DockProgram(mask, memList);
                        programs.Add(program);

                        mask = String.Empty;
                        memList.Clear();
                    }

                    mask = line.Substring(line.IndexOf("=")+1).Trim();
                    //Console.WriteLine(mask);
                }
                else
                {
                    int start = line.IndexOf("[");
                    int end = line.IndexOf("]");
                    string addString = line.Substring(line.IndexOf("[")+1, (end-start-1));
                    string valString = line.Substring(line.IndexOf("=")+1).Trim();

                    memList.Add(new KeyValuePair<long, long>(Int64.Parse(addString), Int64.Parse(valString)));

                    //Console.WriteLine($">> {addString} - {valString}");
                }
            }
            program = new DockProgram(mask, memList);
            programs.Add(program);

            long reasult1 = SolvePart1(programs);
            Console.WriteLine($"Part1 result = {reasult1}");

            long reasult2 = SolvePart2(programs);
            Console.WriteLine($"Part2 result = {reasult2}");
        }

        static long SolvePart1(List<DockProgram> programs)
        {
            Dictionary<long, long> memory = new Dictionary<long, long>();

            foreach(DockProgram program in programs)
            {
                Dictionary<long, long> temp = new Dictionary<long, long>();

                temp = program.MaskNow();

                foreach(KeyValuePair<long, long> kvp in temp)
                {
                    if (memory.ContainsKey(kvp.Key))
                    {
                        memory[kvp.Key] = kvp.Value;
                    }
                    else
                    {
                        memory.Add(kvp.Key, kvp.Value);
                    }
                }
            }
            long sum = 0;
            foreach(KeyValuePair<long, long> kvp in memory)
            {
                sum += kvp.Value;
            }

            return sum;
        }

        static long SolvePart2(List<DockProgram> programs)
        {
            Dictionary<long, long> memory = new Dictionary<long, long>();

            foreach(DockProgram program in programs)
            {
                Dictionary<long, long> temp = new Dictionary<long, long>();

                temp = program.MaskNow2();

                foreach(KeyValuePair<long, long> kvp in temp)
                {
                    if (memory.ContainsKey(kvp.Key))
                    {
                        memory[kvp.Key] = kvp.Value;
                    }
                    else
                    {
                        memory.Add(kvp.Key, kvp.Value);
                    }
                }
            }
            long sum = 0;
            foreach(KeyValuePair<long, long> kvp in memory)
            {
                sum += kvp.Value;
            }

            return sum;
        }
    }

    class DockProgram
    {
        private string _Mask { get; set;}
        private List<KeyValuePair<long, long>> _Mems = new List<KeyValuePair<long, long>>();
        public DockProgram(string theMask, List<KeyValuePair<long, long>> theMems)
        {
            _Mask = theMask;
            _Mems.Clear();
            _Mems.AddRange(theMems);
        }
        
        public Dictionary<long, long> MaskNow()
        {
            Dictionary<long, long> memAlloc = new Dictionary<long, long>();

            foreach(KeyValuePair<long,long> kvp in _Mems)
            {
                if (memAlloc.ContainsKey(kvp.Key))
                {
                    memAlloc[kvp.Key] = ApplyMask(kvp.Value);
                }
                else
                {
                    memAlloc.Add(kvp.Key, ApplyMask(kvp.Value));
                }
            }

            return memAlloc;
        }
        public Dictionary<long, long> MaskNow2()
        {
            Dictionary<long, long> memAlloc = new Dictionary<long, long>();

            foreach(KeyValuePair<long,long> kvp in _Mems)
            {
                List<long> numbers = DecodeAddress(kvp.Key);

                foreach(long num in numbers)
                {
                    if (memAlloc.ContainsKey(num))
                    {
                        memAlloc[num] = kvp.Value;
                    }
                    else
                    {
                        memAlloc.Add(num, kvp.Value);
                    }
                    //memAlloc.Add(num, kvp.Value);
                }
            }

            return memAlloc;
        }
        private List<long>  DecodeAddress(long address)
        {
            List<long> addresses = new List<long>();
            StringBuilder result = new StringBuilder();
            String addressToMask = To36BitNumber(address);

            for(int i = 0; i < _Mask.Length ; i ++)
            {
                if (_Mask[i] == 'X') 
                {
                    result.Append('X');
                }
                else 
                {
                    if (_Mask[i] == '1') result.Append('1');
                    else result.Append(addressToMask[i]);
                }
            }

            int numberOfX = result.ToString().Count(x => x == 'X');

            for(int x = 0; x < Math.Pow(2,numberOfX); x++)
            {
                //Console.WriteLine(ToXBitNumber(x,numberOfX));
                string addressCombination = FillX(result.ToString(),ToXBitNumber(x,numberOfX));
                long num = Convert.ToInt64(addressCombination,2); 
                
                addresses.Add(num);
            }

            return addresses;

        }
        private string To36BitNumber(long number)
        {
            string binary = Convert.ToString(number,2);
            return binary.PadLeft(36,'0');
        }
        private string ToXBitNumber(int number, int bits)
        {
            string binary = Convert.ToString(number,2);
            return binary.PadLeft(bits,'0');
        }
        private string FillX(string address, string fill)
        {
            int fillPos = 0;
            char[] addressChar =  address.ToCharArray();

            for(int x=0; x<addressChar.Length; x++)
            {
                if (addressChar[x] == 'X')
                {
                    addressChar[x] = fill[fillPos];
                    fillPos ++;
                }           
            } 

            return new string(addressChar);   
        }
        private long ApplyMask(long number)
        {
            StringBuilder result = new StringBuilder();
            String numberString = To36BitNumber(number);

            for(int i = 0; i < _Mask.Length ; i ++)
            {
                if (_Mask[i] == 'X') 
                {
                    result.Append(numberString[i]);
                }
                else
                {
                    if (_Mask[i] == numberString[i]) result.Append(numberString[i]);
                    else result.Append(_Mask[i]);
                }
            }
            
            return Convert.ToInt64(result.ToString(),2);   
        }

    }
}
