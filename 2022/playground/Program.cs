using helper;

List<string> input = Helper.ReadList<string>("input.txt");

var result = input
                .Select(inp => new ValueTuple<List<int>, List<int>>(Expand(inp.Split(',')[0]), Expand(inp.Split(',')[0]))).ToList();

foreach(var t in result)
{
    Helper.Print(0, String.Join(" ",t.Item1) + " : " + String.Join(" ", t.Item2));
}


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