using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using helper;

namespace day19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rules = new List<string>();
            List<string> messages = new List<string>();

            bool nextLevel = false;
            foreach(string line in Library.ReadList<string>("test.txt"))
            {
                if(line.Trim().Length == 0) nextLevel = true;
                if(!nextLevel) rules.Add(line);
                else messages.Add(line);
            }

            // sanity test
            // Console.WriteLine(rules[rules.Count-1]);
            // Console.WriteLine(messages[messages.Count-1]);

            long result1 = SolvePart1(rules, messages);
            Library.WriteResult(1, result1);

            long result2 = SolvePart2(rules, messages);
            Library.WriteResult(2, result2);
            
        }
        static long SolvePart1(List<string> rules, List<string> messages)
        {
            Dictionary<int,string> ruleDict = GetRuleDict(rules);
            string rule = ruleDict[0];
            List<string> validCombi = new List<string>();
            Expand(rule,validCombi,ruleDict);

            Library.PrintList<string>(validCombi, true);

            return 0;
        }
        static long SolvePart2(List<string> rules, List<string> messages)
        {
            return 0;
        }
        static Dictionary<int, string> GetRuleDict(List<string> rules)
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            foreach(string rule in rules)
            {
                string[] dividedString = rule.Split(":");
                temp.Add(Int32.Parse(dividedString[0]), dividedString[1].Trim());
            }
            // check
            Console.WriteLine(temp[0]);
            return temp;
        }
        static void Expand(string rule, List<string> valids, Dictionary<int, string> reference, int inner =0)
        {
            string[] rules = rule.Split("|");
            string sub1 = String.Empty;
            int inn = inner;
            foreach(string temp in rules)
            {
                sub1="";
                inn++;
                if(temp.IndexOf("|")>0)
                {
                    Expand(temp, valids,reference, inn);
                }
                else
                { 
                    string[] subRules = temp.Trim().Split(" ");
                    
                    foreach(var subRule in subRules)
                    {
                        if (!subRule.StartsWith('"'))
                        {
                            string subRule2 = reference[Int32.Parse(subRule)];
                            //valids.Add("|");
                            if(subRule2.IndexOf("|")>0) 
                            {
                                
                                Expand(subRule2,valids,reference, inn);
                                //valids.Add("|");
                            }
                            else 
                            {
                                //sub1 += subRule2.Replace("\"",String.Empty);
                                valids.Add(subRule2.Replace("\"",String.Empty));
                                if(inn>1)
                                {
                                    valids.Add("|");
                                }
                                
                            }
                        }
                        
                    }
                    // sub1 +=":";
                    //valids.Add(sub1);
                }
                
            }
            // valids.Add(sub1);
            
        }
        // static string Convert(char rule, string accumm , Dictionary<int, string> reference )
        // {
        //     string tAccumm = accumm;


        // }
    }
}
