/*
--- Day 2: Password Philosophy ---
*/
using System;
using System.Collections;
using System.Linq;
using System.IO;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            int validPasswordCountMethod1 = 0;
            int validPasswordCountMethod2 = 0;

            foreach(string passwordEntry in File.ReadLines("input.txt"))
            {
                string[] decomposedPassword = passwordEntry.Split(' ');

                if (isValidPasswordMethod1(decomposedPassword)) validPasswordCountMethod1 ++;
                if (isValidPasswordMethod2(decomposedPassword)) validPasswordCountMethod2 ++;
            }

            Console.WriteLine($"Method1 result is {validPasswordCountMethod1.ToString()}");
            Console.WriteLine($"Method2 result is {validPasswordCountMethod2.ToString()}");
        }

        static bool isValidPasswordMethod1(
            string[] passwordData
        )
        {
            string range = passwordData[0];
            char key = passwordData[1][0];
            string password = passwordData[2];

            string[] splittedRange = range.Split('-');
            int mininumLenght = Int32.Parse(splittedRange[0]);
            int maximumLenght = Int32.Parse(splittedRange[1]);
            
            int keyCount = passwordData[2].Count( c => c == key);

            if (keyCount>=mininumLenght && keyCount<=maximumLenght) return true;
            else return false;
        }

        static bool isValidPasswordMethod2(
            string[] passwordData
        )
        {
            string range = passwordData[0];
            char key = passwordData[1][0];
            string password = passwordData[2];

            string[] splittedRange = range.Split('-');
            int position1 = Int32.Parse(splittedRange[0]);
            int position2 = Int32.Parse(splittedRange[1]);
            
            bool foundInPos1 = password[position1-1] == key;
            bool foundInPos2 = password[position2-1] == key;
            
            return foundInPos1 ^ foundInPos2;
        }
    }
}
