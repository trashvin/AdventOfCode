using helper;

List<string> input = Helper.ReadList<string>("input.txt");

var result = input
                .Select(inp => new ValueTuple<List<int>, List<int>>(Expand(inp.Split(',')[0]), Expand(inp.Split(',')[0])))
                .ToList();

//foreach(var t in result)
//{
//    Helper.Print(0, String.Join(" ",t.Item1) + " : " + String.Join(" ", t.Item2));
//}

int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };

var result1 = numbers.TakeWhile(n => n < 2);
Helper.Print(0, String.Join(" ", result1));


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