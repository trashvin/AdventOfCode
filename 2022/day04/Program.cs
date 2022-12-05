using helper;

List<string> input = new List<string>();

input = Helper.ReadList<string>("data.txt");
int pairs = 0;
foreach(var line in input)
{
    List<int> part1 = Expand(line.Split(',')[0]);
    List<int> part2 = Expand(line.Split(',')[1]);

    var intersection = part1.Intersect(part2);

    if ((intersection.Count() >= part1.Count) || (intersection.Count() >= part2.Count))
    {
        pairs++;
    }

}

Helper.WriteResult(1,pairs);

//part 2
pairs = 0;
foreach (var line in input)
{
    List<int> part1 = Expand(line.Split(',')[0]);
    List<int> part2 = Expand(line.Split(',')[1]);

    var intersection = part1.Intersect(part2);

    if (intersection.Count() >0)
    {
        pairs++;
    }
}

Helper.WriteResult(2, pairs);

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