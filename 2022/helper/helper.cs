﻿namespace helper;

public static class Helper
{
    public static void WriteResult(int part, long value)
    {
        Console.WriteLine($"Part {part} result = {value}");
    }
    public static void WriteResult(int part, string value)
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
    public static void PrintList<T>(List<T> list, bool oneLine = false)
    {
        Console.WriteLine("----------");
        foreach (T line in list)
        {
            if (oneLine) Console.Write(line + " , ");
            else Console.WriteLine(line);
        }
        Console.WriteLine("----------");
    }
    public static void PrintDict<T, U>(Dictionary<T, U> dict)
    {
        if (dict is null)
        {
            throw new ArgumentNullException(nameof(dict));
        }

        Console.WriteLine("----------");
        foreach (KeyValuePair<T, U> kvp in dict)
        {
            Console.WriteLine($"{kvp.Key} : {kvp.Value}");
        }
        Console.WriteLine("----------");
    }

    public static void Print(int part, string value)
    {
        Console.WriteLine($"Log {part} result = {value}");
    }

}