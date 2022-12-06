# CSharp Learnings

## sorting dict by value
```
var orderedCalElfDictionary = caloriesPerElf.OrderByDescending(key => key.Value);
```

## take the first three in the dict
```
orderedCalElfDictionary.Take(3)
```

## finding index of item in an array
```
string[] opponentMoves = { "A", "B", "C" };
int pos1 = Array.FindIndex(opponentMoves, item => item == moves[0]);
```

## intersections between arrays
```
var inter = lowerHalf.Intersect(upperHalf);

//to check if there is a valid intersection
if (inter.Count() > 0)
{
	total += GetPriority(inter.First());
}
```

## tuples example
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