
// for part 1
using helper;
using System.Runtime.InteropServices;

string alphabet = "abcdefghijklmnopqrstuvwxyz";

int total = 0;

List<string> input = new List<string>();

input = Helper.ReadList<string>("data.txt");

//for part 1

foreach (string line in input)
{
    int mid = line.Length / 2;
    string lowerHalf = line.Substring(0, mid);
    string upperHalf = line.Substring(mid);

    var inter = lowerHalf.Intersect(upperHalf);

    if (inter.Count() > 0)
    {
        total += GetPriority(inter.First());
    }
}

Helper.WriteResult(1, total);

total = 0;

//for part 2

int lineNo = 0;
do
{
    string line1 = input[lineNo];
    string line2 = input[lineNo + 1];
    string line3 = input[lineNo + 2];

    var intersection = line1.Intersect(line2.Intersect(line3));

    if (intersection.Count() > 0)
    {
        total += GetPriority(intersection.First());
    }

    lineNo += 3;


} while (lineNo != input.Count());

Helper.WriteResult(2, total);

int GetPriority(char item)
{
    return item - 'a' >= 0 ? item - 'a' + 1 : item - 'A' + 27;
}


// linq solution
//long PartOne()
//{
//    return input
//        .Select(rucksack =>
//            new ValueTuple<string, string>(
//                rucksack.Substring(0, rucksack.Length / 2),
//                rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2)))
//        .Select(compartments => compartments.Item1.Intersect(compartments.Item2))
//        .Aggregate(0, (sum, commonItem) => sum + GetPriority(commonItem.First()));
//}

//long PartTwo()
//{
//    return input
//        .Chunk(3)
//        .Select(group => group[2].Intersect(group[1].Intersect(group[0])))
//        .Aggregate(0, (sum, commonItem) => sum + GetPriority(commonItem.First()));
//}
