using helper;

List<string> input = new List<string>();

input = Helper.ReadList<string>("data.txt");

bool newContainer = false;
List<string[]> rawStackList = new List<string[]>();
List<string> directions = new List<string>();

// processing the input file
foreach(string line in input)
{
    if (!newContainer)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            newContainer = true;
            continue;
        }
    }

    if (newContainer) directions.Add(line);
    else
    {
        string tempLine = line.Replace("[", "").Replace("]", "").Replace("    "," ");
        rawStackList.Add(tempLine.Split(' '));   
    }
}

List<Stack<string>> stacks = new List<Stack<string>>();
List<Stack<string>> stacks2 = new List<Stack<string>>();

// placing in correct location
for (int i = rawStackList.Count-2; i>=0; i--)
{    
    int stackNo = 0;
    foreach(var item in rawStackList[i])
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                stacks[stackNo].Push(item);
                stacks2[stackNo].Push(item);
            }
            stackNo++;
        }
        catch
        {
            stacks.Add(new Stack<string>());
            stacks2.Add(new Stack<string>());
            if (!string.IsNullOrWhiteSpace(item))
            {
                stacks[stackNo].Push(item);
                stacks2[stackNo].Push(item);
            }
            stackNo++;
        }      
    }
}

// solve part 1
foreach (var inst in directions)
{
    Tuple<int, int, int> dir = GetDirection(inst);

    for (int steps = 0; steps < dir.Item1; steps++)
    {
        var crate = stacks[dir.Item2].Pop();
        stacks[dir.Item3].Push(crate);
    }

}

Helper.WriteResult(1, GetTopCrates(stacks));

// solve part 2

foreach (var inst in directions)
{
    Tuple<int, int, int> dir = GetDirection(inst);

    Stack<string> tempHold = new Stack<string>();
    for (int steps = 0; steps < dir.Item1; steps++)
    { 
            var crate = stacks2[dir.Item2].Pop();
            tempHold.Push(crate);
    }

    while (tempHold.Count > 0) stacks2[dir.Item3].Push(tempHold.Pop());

}

Helper.WriteResult(2, GetTopCrates(stacks2));

string GetTopCrates(List<Stack<string>> stacksList)
{
    string result = string.Empty;
    foreach (var dat in stacksList)
    {
        result += dat.Pop();
    }
    return result;
}

Tuple<int, int, int> GetDirection(string data)
{
    data = data.Replace("move", "").Replace("from", "").Replace("to", "");
    string[] myDir = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    return Tuple.Create(Int32.Parse(myDir[0]), Int32.Parse(myDir[1])-1, Int32.Parse(myDir[2])-1);
}