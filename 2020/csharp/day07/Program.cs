using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace day07
{
    class Program
    {
        static Dictionary<string,Dictionary<string,int>> regulations = 
                new Dictionary<string, Dictionary<string, int>>();
        static List<long> bagCountList = new List<long>();

        static void Main(string[] args)
        {
            List<string> rules = new List<string>();
            
            foreach(string rule in File.ReadLines("input.txt"))
            {
                rules.Add(rule);
            }
            
            BuildRegulation(rules);
            //PrintRegulations();

            //SolvePart1("shiny gold bags");
            SolvePart2("shiny gold bags");
        }

        static void SolvePart1(string bag)
        {
            int bagCount = 0;
            // HashSet<string> validBags = new HashSet<string>();
            
            foreach(KeyValuePair<string,Dictionary<string,int>> rule in regulations)
            {
                //Console.Write(rule.Key.Replace("bags","").Trim() + " -> ");
            
                if(CanContainBag(bag, rule.Value))
                {
                    bagCount++;
                }   
                
                //Console.WriteLine();             
            }
            //Console.WriteLine($"{validBags.Count}");
            Console.WriteLine($"Part1 Result = {bagCount}");
        }

        static bool CanContainBag(string bag, Dictionary<string,int> rules)//, StringBuilder str)
        {
            foreach(KeyValuePair<string,int> subBag in rules)
            {
                //Console.Write("");
                //Console.Write(PrintKvp(subBag) + " ");
                if(String.Compare(subBag.Key,"no other bags") == 0)
                {
                    //str.Append(PrintKvp(subBag) + " X ");
                    //Console.Write("END");
                    continue;
                }
                else if(String.Compare(subBag.Key,bag) == 0)
                {
                    //Console.WriteLine($"");
                    //str.Append(PrintKvp(subBag) + " ## ");
                    //Console.Write("M A T C H");
                    return true;
                }
                else
                {
                    //str.Append(PrintKvp(subBag) + " - ");
                    //Console.Write(" >>> ");
                    if(CanContainBag(bag,regulations[subBag.Key]))
                    {
                        //Console.WriteLine("NEXT RULE");
                        return true;
                    }                    
                }
            }

            return false;
        }

        static void SolvePart2(string bag)
        {
            //int bagCount = 0;
            // HashSet<string> validBags = new HashSet<string>();
            
            // 
            
            bagCountList.Clear();
            GetCountBag(regulations[bag], 1);
            int result = 0; //bagCountList.Sum();
              
            

            //Console.WriteLine($"{validBags.Count}");
            Console.WriteLine($"Part2 Result = {result}");
        }

        static long GetCountBag(Dictionary<string,int> rules, long sum)
        {
            long total = sum;
            //long innerTotal = 0;
            foreach(KeyValuePair<string,int> rule in rules)
            {     
                if(string.Compare(rule.Key,"no other bags") !=0)
                {
                    long prevCounts = GetCountBag(regulations[rule.Key], total);
                    total = total + rule.Value*prevCounts;


                    // innerTotal = rule.Value;
                    
                    // Console.Write($"----");
                    // Console.WriteLine($">>{PrintKvp(rule)} : {total} : {innerTotal}");
                    // total = total + rule.Value* (GetCountBag(regulations[rule.Key], total));
                    // innerTotal += total;
                    // // Console.WriteLine($"<<{PrintKvp(rule)} : {total} : {totalSum}");
                    
                    // //bagCountList.Add(rule.Value);
                    // //GetCountBag(regulations[rule.Key], innerTotal);
                    // Console.WriteLine($"<<{PrintKvp(rule)} : {total} : {innerTotal}");
                }
                // else
                // {
                //     total = total + total*rule.Value;
                //     totalSum = totalSum + total;  
                //     //Console.WriteLine($"{PrintKvp(rule)} : {total} : {totalSum}");
                    
                //     return rule.Value;
                // }
            }
            // part2 = totalSum;
            return total;
        }
        static void BuildRegulation(List<string> rules)
        {
            foreach(string rule in rules)
            {
                int containIndicator = rule.IndexOf("contain");
                string ruleName = rule.Substring(0,containIndicator).Trim();
                // Console.WriteLine(ruleName);
                string[] subRules = rule.Substring(containIndicator+7).Split(','); 

                Dictionary<string,int> innerBags = new Dictionary<string, int>();

                foreach(string subRule in subRules)
                {
                    string tempRule = subRule.Trim();
                    //Console.WriteLine(subRule);
                    int count = 0;
                    string item = "no other bags";
                    if (!subRule.Trim().StartsWith("no"))
                    {
                        count = Int32.Parse(tempRule[0].ToString());
                        item = subRule.Substring(3).Trim().Replace(".","");
                        if (!item.EndsWith("s")) item = item + "s";
                    }
                    innerBags.Add(item,count);
                }

                regulations.Add(ruleName, innerBags);
            }

            
        }

        static void PrintRegulations()
        {
            foreach(KeyValuePair<string,Dictionary<string,int>> rule in regulations)
            {
                StringBuilder inner = new StringBuilder();
                foreach(KeyValuePair<string,int> innerBag in rule.Value)
                {
                    inner.Append($"{innerBag.Key.Replace("bags","").Trim()}");// : {innerBag.Value} ;");
                }

                Console.WriteLine($"{rule.Key.Replace("bags","").Trim()} -> {inner.ToString()}");
            }
        }

        static string PrintRule(KeyValuePair<string,Dictionary<string,int>> rule)
        {
            
            StringBuilder inner = new StringBuilder();
            foreach(KeyValuePair<string,int> innerBag in rule.Value)
            {
                inner.Append($"{innerBag.Key.Replace("bags","").Trim()}: {innerBag.Value} ;");
            }

            return $"{rule.Key.Replace("bags","").Trim()} -> {inner.ToString()}";
            
        }

        static string PrintKvp(KeyValuePair<string,int> rule)
        {
            return $"{rule.Key.Replace("bags","").Trim()} -> {rule.Value}";      
        }
    
        
    }
}
