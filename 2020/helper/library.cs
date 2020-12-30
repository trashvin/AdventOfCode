using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;


namespace helper
{
    public static class Library
    {
        public static void WriteResult(int part, long value)
        {
            Console.WriteLine($"Part {part} result = {value}");
        }
        public static void WriteResult(int part, int value)
        {
            Console.WriteLine($"Part {part} result = {value}");
        }
        public static List<T> ReadList<T>(string fileName)
        {
            List<T> list = new List<T>();

            foreach (string line in File.ReadLines(fileName))
            {
                list.Add((T)Convert.ChangeType(line, typeof(T)));
            }

            return list;
        }
        public static void PrintList<T>(List<T> list)
        {
            Console.WriteLine("----------");
            foreach (T line in list)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("----------");
        }
    }
}
