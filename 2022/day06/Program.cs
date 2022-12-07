
using helper;

String message = File.ReadAllText("data.txt");
int startIndex = 0;

// part 1

while((startIndex + 4)<message.Length)
{
    string temp = message.Substring(startIndex, 4);
    
    if (IsStart(temp,4)) break;

    startIndex++;
}
Helper.WriteResult(1, startIndex+4);

// part 2
startIndex = 0;
while ((startIndex + 14) < message.Length)
{
    string temp = message.Substring(startIndex, 14);

    if (IsStart(temp,14)) break;

    startIndex++;
}
Helper.WriteResult(2, startIndex + 14);


bool IsStart(string sequence, int lenght)
{
    string origSequence = sequence; 
    foreach(var item in sequence)
    {
        if (origSequence.Replace(item.ToString(), String.Empty).Trim().Length != (lenght-1)) return false;
    }
    return true;
}