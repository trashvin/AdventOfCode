using helper;

List<string> input = Helper.ReadList<string>("data.txt");

List<int> cycles = new List<int>();

// part 1
int runningValue = 1;
foreach (string line in input)
{
    if (line.StartsWith("noop"))
    {
        cycles.Add(runningValue);
    }
    else
    {
        int addVal = Int32.Parse(line.Substring(4));
        cycles.Add(runningValue);
        cycles.Add(runningValue);
        runningValue += addVal;
    }
}

var result = (20 * cycles[19])
                + (60 * cycles[59])
                + (100 * cycles[99])
                + (140 * cycles[139])
                + (180 * cycles[179])
                + (220 * cycles[219]);

Helper.WriteResult(1, result.ToString());

// part 2
var cycleCount = 0;
var addCycle = 0;
var position = 1;
var output = "";
foreach (string line in input)
{
    if (line.StartsWith("noop"))
    {
        cycleCount++;
        output += AppendPixel(cycleCount, position);

        if (cycleCount % 40 == 0) output += "\n";
    }
    else
    {
        int addVal = Int32.Parse(line.Substring(4));
        while (addCycle<2)
        {
            cycleCount++;
            output += AppendPixel(cycleCount, position);
           
            if (addCycle == 1) position += addVal;
            
            addCycle++;

            if (cycleCount % 40 == 0) output += "\n";
        }

        addCycle = 0;
    }
}

Helper.WriteResult(2, "\n" + output);

string AppendPixel(int cycle, int position)
{
    if ((cycle - 1) % 40 == position - 1 || (cycle - 1) % 40 == position || (cycle - 1) % 40 == position + 1)
        return "#";
    else
        return ".";
  
}

