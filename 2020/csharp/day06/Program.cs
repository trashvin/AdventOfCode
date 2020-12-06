using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace day06
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilder groupDeclaration = new StringBuilder();
            List<string> declarations = new List<string>();
            
            //File.AppendAllText("test.txt","\n");
            foreach(string dataLine in File.ReadLines("input.txt"))
            {
                if (String.IsNullOrWhiteSpace(dataLine.Trim()))
                {
                    declarations.Add(groupDeclaration.ToString());
                    groupDeclaration.Clear();
                }
                else
                {
                    groupDeclaration.Append(dataLine + ",");
                }
            }
            declarations.Add(groupDeclaration.ToString());

            //sanity check
            // foreach(string line in declarations)
            // {
            //     Console.WriteLine(line);
            // }

            int totalYes = 0;
            foreach(string line in declarations)
            {
                totalYes += GetSumOfYesVersion1(line);
            }

            Console.WriteLine($"Part1 Result = {totalYes}");

            totalYes = 0;
            foreach(string line in declarations)
            {
                totalYes += GetSumOfYesVersion2(line);
            }

            Console.WriteLine($"Part2 Result = {totalYes}");

        }
        static int GetSumOfYesVersion1(string groupDeclaration)
        {
            // clean the data, remove the ","
            groupDeclaration = groupDeclaration.Replace(",",String.Empty);

            HashSet<int> yesList = new HashSet<int>();
            int yesCount = 0;
            for(int index = 0 ; index < groupDeclaration.Length; index++)
            {
                if (yesList.Add(groupDeclaration[index]))
                {
                    yesCount ++;
                }
            }

            return yesCount;
        }

        static int GetSumOfYesVersion2(string groupDeclaration)
        {
            HashSet<int> yesList = new HashSet<int>();
            string[] answerPerPerson = groupDeclaration.Split(',',StringSplitOptions.RemoveEmptyEntries);
            Dictionary<char,int> tally = new Dictionary<char, int>();

            for(int outer=0; outer<answerPerPerson.Length; outer++)
            {
                string answer = answerPerPerson[outer];

                for(int index = 0 ; index < answer.Length; index++)
                {      
                    if(tally.ContainsKey(answer[index]))
                    {
                        tally[answer[index]]++;
                    }
                    else
                    {
                        tally.Add(answer[index],1);
                    }
                            
                }
            }

            int yesCount =0;
            foreach(KeyValuePair<char, int> kvp in tally)
            {

                // character count == the # of persons in the group
                if(kvp.Value == answerPerPerson.Length)
                {
                    yesCount++;
                }
            }    
            return yesCount;
        }
    }
}
