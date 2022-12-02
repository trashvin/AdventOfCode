// See https://aka.ms/new-console-template for more information
using helper;
using System.Runtime.InteropServices;

List<string> input = Helper.ReadList<string>("data.txt");
Dictionary<int,int> caloriesPerElf = new Dictionary<int, int>();

int elfNumber = 0;
int tempTotalCal = 0;

//start of part 1

foreach(var calorie in input)
{
    if (!String.IsNullOrWhiteSpace(calorie))
    {
        tempTotalCal += Int32.Parse(calorie);
    }
    else 
    {
        caloriesPerElf.Add(elfNumber, tempTotalCal);
        elfNumber++;
        tempTotalCal = 0;
    }
}

var orderedCalElfDictionary = caloriesPerElf.OrderByDescending(key => key.Value);

Helper.WriteResult(1, orderedCalElfDictionary.Take(1).First().Value);

// start of part 2

int totalCalOfThreeElf = 0;

foreach(KeyValuePair<int,int> elf in orderedCalElfDictionary.Take(3))
{
    Console.WriteLine($"{elf.Key} : {elf.Value}");
    totalCalOfThreeElf += elf.Value;
}

Helper.WriteResult(2,totalCalOfThreeElf);

Console.ReadLine();

