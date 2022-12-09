using helper;

List<string> input = new List<string>();

input = Helper.ReadList<string>("data.txt");

var matrix = input
    .Select(myList => myList.ToCharArray()).ToList();

// part 1
int visible = (2 * matrix.Count()) + (2 * matrix.First().Length) -4;
for(int row = 1; row<matrix.Count()-1 ; row++)
{
    for(int col = 1; col < matrix.First().Length -1; col++)
    {
        if (IsVisible(row, col)) visible++;
    }
}

Helper.WriteResult(1, visible);

// part 2
int score = 0;
for (int row = 1; row < matrix.Count() - 1; row++)
{
    for (int col = 1; col < matrix.First().Length - 1; col++)
    {
        int tempScore = ComputeScenicScore(row, col);
        if ( tempScore > score ) score = tempScore;
    }
}

Helper.WriteResult(2, score);


bool IsVisible(int row, int col)
{
    char current = matrix[row][col];
    var leftResult = matrix[row].Take(new Range(0, col))
        .Where(val => val>=current)
        .Count() == 0;

    var rightResult = matrix[row].Take(new Range(col+1, matrix.First().Length))
        .Where(val => val >= current)
        .Count() == 0;

    var pivot = matrix.Take(new Range(0,matrix.Count()))
        .Select(val => val[col]).ToList();

    var topResult = pivot.Take(new Range(0, row))
        .Where(val => val >= current)
        .Count() == 0;

    var downResult = pivot.Take(new Range(row+1, matrix.Count()))
        .Where(val => val >= current)
        .Count() == 0;

    if ( leftResult || rightResult || topResult || downResult ) return true;

    return false;
}

int ComputeScenicScore(int row, int col)
{
    char current = matrix[row][col];
    var left = matrix[row].Take(new Range(0, col)).Reverse();

    int leftCount = 0;
    foreach(var tree in left)
    {
        if (tree >= current)
        {
            leftCount++;
            break;
        }
        else leftCount++;
    }
   
    var right = matrix[row].Take(new Range(col + 1, matrix.First().Length));
    int rightCount = 0;
    foreach (var tree in right)
    {
        if (tree >= current)
        {
            rightCount++;
            break;
        }
        else rightCount++;
    }

    var pivot = matrix.Take(new Range(0, matrix.Count()))
        .Select(val => val[col]).ToList();

    var top = pivot.Take(new Range(0, row)).Reverse();
    int topCount = 0;
    foreach (var tree in top)
    {
        if (tree >= current)
        {
            topCount++;
            break;
        }
        else topCount++;
    }

    var down = pivot.Take(new Range(row + 1, matrix.Count()));
    int downCount = 0;
    foreach (var tree in down)
    {
        if (tree >= current)
        {
            downCount++;
            break;
        }
        else downCount++;
    }

    return leftCount * rightCount * topCount * downCount;
}
