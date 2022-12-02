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