using helper;
using System.Security.Cryptography.X509Certificates;

var input = Helper.ReadList<string>("test.txt");

// part1 

var pairs = new List<(string,string)>();
int dataCount = 0;
do
{
    pairs.Add(ValueTuple.Create(input[dataCount], input[dataCount + 1]));
    dataCount += 2;
}while(dataCount < input.Count-2);

var allRights = 0;

int index = 0;
foreach(var pair in pairs)
{
    List<List<string>>  left = Expand(pair.Item1);
    List<List<string>> right = Expand(pair.Item2);

    if (left.Count < right.Count)
    {
        allRights += index + 1;
    }

    index++;
}


List<List<string>> Expand(string line)
{
    List<List<string>> res = new List<List<string>>();

    char open = '[';
    char close = ']';
    //Stack<char> temp = 
    string data = string.Empty;
    bool set = false;
    foreach(var letter in line)
    {
       if (letter == open)
        {
            set = true;
            continue;
        }
       else if ( letter == close)
        {
            set = false;
            res.Add(data.Split(',').ToList());
            data = string.Empty;
        }
        else
        {
            data += letter;
        }
    }


    return res;
}