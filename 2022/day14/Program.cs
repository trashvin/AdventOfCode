using helper;

var input = Helper.ReadList<string>("test.txt");

// part 1
string emptyLine = new string('.',700);
List<string> cave = new List<string>();
List<string> cave2 = new List<string>();
int maxY = 0;
for (int i = 0; i < 200; i++) cave.Add(emptyLine);
var balancer = 200;

foreach (var line in input)
{
    var prevX = 0;
    var prevY = 0;
    foreach (var range in line.Split("->", StringSplitOptions.RemoveEmptyEntries))
    {
        var x = Int32.Parse(range.Split(",", StringSplitOptions.RemoveEmptyEntries)[0])-balancer;
        var y = Int32.Parse(range.Split(",", StringSplitOptions.RemoveEmptyEntries)[1]);
        
        if ( y>maxY) maxY = y;

        cave[y] = ReplaceChar(cave[y], '#', x);

        if (x == prevX)
        {
            var tempY = y;
            while (tempY != prevY)
            {
                cave[tempY] = ReplaceChar(cave[tempY], '#', x);
                tempY = (tempY >= prevY) ? tempY - 1 :tempY + 1;
            }
        }
        if (y == prevY)
        {
            var tempX = x;
            while (tempX != prevX)
            {
                cave[y] = ReplaceChar(cave[y], '#',tempX);
                tempX = (tempX >= prevX) ? tempX - 1 : tempX  + 1;
            }
        }
        prevX = x;
        prevY = y;
    }
}

cave2.Clear();  
cave2.AddRange(cave);

// part 1
//position sand
var startY = 0;
var startX = 500 - balancer;
cave[startY] = ReplaceChar(cave[startY], '+', startX);
int sandCount = 0;
//start pour
//Helper.PrintList(cave);

while (startY<cave.Count-1)
{
    var free = IsFree(cave, startX, startY);

    switch(free)
    {
        case 'd':
            startY++;       
            break;
        case 'l':
            startX--;
            startY++;
            break;
        case 'r':
            startX++;
            startY++;
            break;
        default:
            cave[startY] = ReplaceChar(cave[startY], 'o', startX);
            //Helper.PrintList(cave);
            startY = 0;
            startX = 500 - balancer;
            sandCount++;    
            continue;
    }
}

Helper.WriteResult(1, sandCount);

// part 2
//place the ground
string ground = new string('#', 700);
cave2[maxY + 2] = ground;

//position sand
startY = 0;
startX = 500 - balancer;
cave2[startY] = ReplaceChar(cave2[startY], '+', startX);
var sandCount2 = 0;
var stop = false;
//start pour

while (!stop)
{
    var free = IsFree(cave2, startX, startY);

    switch (free)
    {
        case 'd':
            startY++;
            break;
        case 'l':
            startX--;
            startY++;
            break;
        case 'r':
            startX++;
            startY++;
            break;
        default:
            cave2[startY] = ReplaceChar(cave2[startY], 'o', startX);
            sandCount2++;
            //Helper.PrintList(cave2);
            if (startY == 0) stop = true;
            startY = 0;
            startX = 500 - balancer;
            continue;
    }
}

Helper.WriteResult(2, sandCount2);

string ReplaceChar(string line, char replacement, int pos)
{
    var tempChars = line.ToCharArray();
    tempChars[pos] = replacement;
    return new string(tempChars);
}

char IsFree(List<string> theCave, int x, int y)
{
    var free = 'n';
    // down
    if ((theCave[y + 1][x] == '#') || (theCave[y + 1][x] == '+') || (theCave[y + 1][x] == 'o'))
    {
        // left
        if ((theCave[y + 1][x - 1] == '#') || (theCave[y + 1][x - 1] == '+') || (theCave[y + 1][x-1] == 'o'))
        {
            // right
            if ((theCave[y + 1][x + 1] == '#') || (theCave[y + 1][x + 1] == '+') || (theCave[y + 1][x+1] == 'o') )
            {
                free = 'n';
            }
            else free = 'r';
        }
        else free = 'l';
    }
    else free = 'd';

    return free;
}
