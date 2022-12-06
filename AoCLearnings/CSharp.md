# CSharp Learnings

1. [sorting dict by value](#1)
2. [take the first three in the dict](#2)
3. [finding index of item in an array](#3)
4. [intersections between arrays](#4)
5. [tuple example](#5)

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