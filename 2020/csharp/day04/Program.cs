using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> passports = new List<string>();
            int lineCount=0;
            StringBuilder passport = new StringBuilder();
            foreach(string dataLine in File.ReadLines("input.txt"))
            {
                if (String.IsNullOrWhiteSpace(dataLine.Trim()))
                {
                    passports.Add(passport.ToString());
                    passport.Clear();
                    lineCount++;
                }
                else
                {
                    passport.Append(dataLine + " ");
                }
            }
            passports.Add(passport.ToString());
            Console.WriteLine($"linecount : {lineCount}");

            // int validCountPart1 = 0;
            // int inVal=0;
            // foreach(string passportEntry in passports)
            // {
            //     if(IsValidPassportPart1(passportEntry)) 
            //     {
            //         //Console.WriteLine(passportEntry);
            //         validCountPart1++;
            //     }
            //     else
            //     {
            //         inVal++;
            //     }
            // }
            // Console.WriteLine($"{validCountPart1 + inVal}");
            // Console.WriteLine($"Part1 Result = {validCountPart1}");
            int validCountPart2 = 0;
            foreach(string passportEntry in passports)
            {
                if(IsValidPassportPart2(passportEntry))
                {
                    validCountPart2 ++;
                }
            }

            Console.WriteLine($"Part2 Result = {validCountPart2}");
        }

        static bool IsValidPassportPart1(string passport)
        {
            //Console.WriteLine("---"+passport);
            List<string> validPoints = new List<string>()
            {
                "byr", "iyr","eyr", "hgt" , "hcl" ,"ecl", "pid" 
            };
            int validCount = 0;
            foreach(string validPoint in validPoints)
            {
                if (passport.Contains(validPoint+":"))
                {
                    //Console.WriteLine(validPoint);
                    validCount++;
                }
            }
            //Console.WriteLine(validCount);
            return validCount>=(validPoints.Count);
        }

        static bool IsValidPassportPart2(string passport)
        {
            List<string> validPoints = new List<string>()
            {
                "byr", "iyr","eyr", "hgt" , "hcl" ,"ecl", "pid" 
            };
            string[] elements = passport.Split(' ');
            int validCount = 0;
            foreach(string field in elements)
            {
                string[] pairs = field.Split(':');

                switch(pairs[0])
                {
                    case "byr":
                        if (pairs[1].Length ==4)
                        {
                            int year = 0;
                            
                            if(Int32.TryParse(pairs[1],out year))
                            {
                                if(year>=1920 && year<=2002)
                                {
                                    validCount++;
                                }
                            }
                        }
                        break;
                    case "iyr":
                        if (pairs[1].Length ==4)
                        {
                            int year = 0;
                            
                            if(Int32.TryParse(pairs[1],out year))
                            {
                                if(year>=2010 && year<=2020)
                                {
                                    validCount++;
                                }
                            }
                        }
                        break;
                    case "eyr":
                        if (pairs[1].Length ==4)
                        {
                            int year = 0;
                            
                            if(Int32.TryParse(pairs[1],out year))
                            {
                                if(year>=2020 && year<=2030)
                                {
                                    validCount++;
                                }
                            }
                        }
                        break;
                    case "hgt":
                        Regex rx = new Regex(@"[\d](in|cm)$",RegexOptions.Compiled | RegexOptions.IgnoreCase);

                        if (rx.Matches(pairs[1]).Count>0)
                        {
                            
                            string temp=string.Empty;
                            int tempVal=0;
                            if(pairs[1].EndsWith("in"))
                            {
                                temp = pairs[1].Replace("in","");
                                if(Int32.TryParse(temp,out tempVal))
                                {
                                    if(tempVal>=59 && tempVal<=76) 
                                    {
                                        //Console.WriteLine(pairs[1]);
                                        validCount++;
                                    }
                                }
                            }
                            else
                            {
                                temp = pairs[1].Replace("cm","");
                                if(Int32.TryParse(temp,out tempVal))
                                {
                                    if(tempVal>=150 && tempVal<=193) 
                                    {
                                        
                                        validCount++;
                                    }
                                }
                            }
                        }

                        break;
                    case "hcl":
                        Regex rx2 = new Regex(@"^#([a-f,0-9]{6})$",RegexOptions.Compiled | RegexOptions.IgnoreCase);

                        if(rx2.Matches(pairs[1]).Count>0) 
                        {
                            //Console.WriteLine(pairs[1]);
                            validCount++;
                        }

                        break;
                    case "ecl":
                        Regex rx3 = new Regex(@"(\bamb\b)|(\bblu\b)|(\bbrn\b)|(\bgry\b)|(\bgrn\b)|(\bhzl\b)|(\both\b)",RegexOptions.Compiled | RegexOptions.IgnoreCase);

                        if(rx3.Matches(pairs[1]).Count>0) 
                        {
                            //Console.WriteLine(pairs[1]);
                            validCount++;
                        }
                        break;
                    case "pid":
                        Regex rx4 = new Regex(@"\d{9}",RegexOptions.Compiled | RegexOptions.IgnoreCase);

                        if(rx4.Matches(pairs[1]).Count>0) 
                        {
                            if(pairs[1].Length == 9)
                            {
                                Console.WriteLine(pairs[1]);
                                validCount++;
                            }
                            
                        }
                        break;
                    default:
                        break;
                }

            }

            // int validCount = 0;
            // foreach(string validPoint in validPoints)
            // {
            //     if (passport.Contains(validPoint+":"))
            //     {
            //         //Console.WriteLine(validPoint);
            //         validCount++;
            //     }
            // }
            //Console.WriteLine(validCount);
            return validCount>=(validPoints.Count);
        }
    }
}
