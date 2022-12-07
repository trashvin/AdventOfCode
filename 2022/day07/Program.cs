using helper;

List<string> input = Helper.ReadList<string>("data.txt");

Stack<string> location = new Stack<string>();
Dictionary<string,long> spaces = new Dictionary<string, long>();
// part 1
long totalSpaces = 0;
int counter = 0;
foreach(var line in input)
{
    string command = String.Empty;
    string arg = String.Empty;
    long space = 0;

    var result = ParseLine(line);
    if (line.StartsWith('$') || (line.StartsWith("dir")))
    {
        
        command = result.Item1;
        arg = result.Item2;

        if (command=="cd")
        {
            if (arg.StartsWith(".."))
            {
                var prev = location.Peek();
                location.Pop();
                spaces[location.Peek()] += spaces[prev];
            }
            else
            {
                
                if (!spaces.ContainsKey(arg))
                {
                    location.Push(arg);
                    spaces.Add(arg, 0);
                }
                else
                {
                    arg += counter.ToString();
                    counter++;
                    location.Push(arg);
                    spaces.Add(arg, 0);
                }
            }
        }
    }
    else
    {
        space = Int64.Parse(result.Item1);
        arg = result.Item2;

        String current = location.Peek();
        spaces[current] += space;
    }
}

// clear the stack
while(location.Count > 1)
{
    var prev = location.Peek();
    location.Pop();
    spaces[location.Peek()] += spaces[prev];
}

foreach(var dir in spaces)
{
    if (dir.Value <= 100000) totalSpaces += dir.Value;
}

Helper.WriteResult(1, totalSpaces);

// part 2
long optimalSpace = -1;
long freeSpace = 70_000_000 - spaces["/"];

foreach(var dir in spaces)
{
    if(freeSpace + dir.Value >= 30_000_000)
    {
        if (optimalSpace == -1)
        {
            optimalSpace = dir.Value;
        }
        else
        {
            if (dir.Value < optimalSpace) optimalSpace = dir.Value;
        }
    }
}

Helper.WriteResult(2, optimalSpace);

Tuple<string, string> ParseLine(string line)
{
    string op1 = String.Empty;
    string op2 = String.Empty;

    line = line.Replace("$", String.Empty).Trim();
    string[] lines = line.Split(' ');

    return (lines.Count() > 1)?
        Tuple.Create(lines[0], lines[1]):
        Tuple.Create(lines[0], String.Empty);
}
