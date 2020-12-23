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
    }
}
