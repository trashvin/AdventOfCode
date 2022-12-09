# CSharp Learnings

1. [sorting dict by value](#1)
2. [take the first three in the dict](#2)
3. [finding index of item in an array](#3)
4. [intersections between arrays](#4)
5. [tuple example](#5)
6. [processing a list using lambda](#6)
7. [analyze a list based on a condition using lambda](#7)
8. [using TakeWhile in C#](#8)

## sorting dict by value <a name="1"></a>
```
var orderedCalElfDictionary = caloriesPerElf.OrderByDescending(key => key.Value);
```

## take the first three in the dict  <a name="2"></a>
```
orderedCalElfDictionary.Take(3)
```

## finding index of item in an array <a name="3"></a>
```
string[] opponentMoves = { "A", "B", "C" };
int pos1 = Array.FindIndex(opponentMoves, item => item == moves[0]);
```

## intersections between arrays  <a name="4"></a>
```
var inter = lowerHalf.Intersect(upperHalf);

//to check if there is a valid intersection
if (inter.Count() > 0)
{
	total += GetPriority(inter.First());
}
```

## tuples example  <a name="5"></a>
```
// sample method
Tuple<int, int, int> GetDirection(string data)
{
    data = data.Replace("move", "").Replace("from", "").Replace("to", "");
    string[] myDir = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    return Tuple.Create(Int32.Parse(myDir[0]), Int32.Parse(myDir[1])-1, Int32.Parse(myDir[2])-1);
}

//call
Tuple<int, int, int> dir = GetDirection(inst);
```

## processing a list using lambda  <a name="6"></a>
```
// sample input from input.txt
// 2-4,6-8
// 2-3,4-5

// projected output
// 2 3 4 : 6 7 8
// 2 3 : 4 5

// needed helper to expand a range to list
List<int> Expand(string range)
{
    string[] ranges = range.Split('-');

    List<int> newRange = new List<int>();
    for (int count = Int32.Parse(ranges[0]); count <= Int32.Parse(ranges[1]); count++)
    {
        newRange.Add(count);
    }
    return newRange;
}

// the lambda example
List<string> input = Helper.ReadList<string>("input.txt");

var result = input
             .Select(inp => new ValueTuple<List<int>, List<int>>(Expand(inp.Split(',')[0]), Expand(inp.Split(',')[0])))
			 .ToList();

foreach(var t in result)
{
    // use String.Join to expand print
    Helper.Print(0, String.Join(" ",t.Item1) + " : " + String.Join(" ", t.Item2));
}
```

## analyze a list based on a condition using lambda <a name="7"></a>
```
// check if all elements in the list are lower than current
current = 7;
var leftResult = list.Take(new Range(0, 20))
        .Where(val => val> current)
        .Count() == 0;
```

## using TakeWhile in C# <a name="8"></a>
```
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };

// take only those less than 2
var result = numbers.TakeWhile(n => n < 2);
```