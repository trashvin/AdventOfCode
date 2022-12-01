// See https://aka.ms/new-console-template for more information
using helper;
using System.Runtime.InteropServices;

List<string> input = Helper.ReadList<string>("data.txt");
Dictionary<int,int> caloriesPerElf = new Dictionary<int, int>();

int elfNumber = 0;
int tempTotalCal = 0;
int highestElf = 0;
int highestCal = 0;

//part 1

foreach(var calorie in input)
{
    if (!String.IsNullOrWhiteSpace(calorie))
    {
        tempTotalCal += Int32.Parse(calorie);
    }
    else 
    {
        caloriesPerElf.Add(elfNumber, tempTotalCal);

        if(tempTotalCal > highestCal)
        {
            highestCal = tempTotalCal;
            highestElf = elfNumber;
        }

        elfNumber++;
        tempTotalCal = 0;
    }
}

Helper.WriteResult(1, highestCal);
int totalCalOfThreeElf = 0;
// start of part 2
foreach(KeyValuePair<int,int> elf in caloriesPerElf.OrderByDescending(key=>key.Value).Take(3))
{
    Console.WriteLine($"{elf.Key} : {elf.Value}");
    totalCalOfThreeElf += elf.Value;
}

Helper.WriteResult(2,totalCalOfThreeElf);