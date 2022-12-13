using helper;

List<string> input = Helper.ReadList<string>("test.txt");

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


