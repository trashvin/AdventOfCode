using helper;

List<string> input = new List<string>();

input = Helper.ReadList<string>("data.txt");

var movements = input
    .Select(val => new Tuple<string, int>(val.Substring(0,1), Int32.Parse(val.Substring(2))));

Dictionary<string, int> headLoc = new Dictionary<string, int>();
Dictionary<string, int> tailLoc = new Dictionary<string, int>();
headLoc.Add("y", 1);
headLoc.Add("x", 1);
tailLoc.Add("y", 1);
tailLoc.Add("x", 1);

List<string> headPath = new List<string>();
headPath.Add(headLoc["x"] + ":" + headLoc["y"] + " > ");

List<string> tailPath = new List<string>();
tailPath.Add(tailLoc["x"] + ":" + tailLoc["y"] + " > ");
var prevDir = String.Empty;

foreach (var movement in movements)
{
    var dir = movement.Item1;
    var steps = movement.Item2;

    for(int step = 0; step < steps; step++)
    {
        if (dir == "R") headLoc["x"] += 1;
        else if (dir == "L") headLoc["x"] -= 1;
        else if (dir == "U") headLoc["y"] += 1;
        else headLoc["y"] -= 1;

        int xDisplacement = headLoc["x"] - tailLoc["x"];
        int yDisplacement = headLoc["y"] - tailLoc["y"];

        if (xDisplacement > 1)
        {
            tailLoc["x"] += 1;
            if (yDisplacement > 0) tailLoc["y"] += 1;
            else if(yDisplacement < 0) tailLoc["y"] -= 1;
        } 
        else if(xDisplacement < -1)
        {
            tailLoc["x"] -= 1;
            if (yDisplacement > 0) tailLoc["y"] += 1;
            else if (yDisplacement < 0) tailLoc["y"] -= 1;
        }
        else if (yDisplacement > 1)
        {
            tailLoc["y"] += 1;
            if (xDisplacement > 0) tailLoc["x"] += 1;
            else if (xDisplacement < 0) tailLoc["x"] -= 1;
        }
        else if (yDisplacement < -1)
        {
            tailLoc["y"] -= 1;
            if (xDisplacement > 0) tailLoc["x"] += 1;
            else if (xDisplacement < 0) tailLoc["x"] -= 1;
        }

        headPath.Add(headLoc["x"] + ":" + headLoc["y"] + " > ");
        tailPath.Add(tailLoc["x"] + ":" + tailLoc["y"] + " > ");
    }
    
    
}

Helper.WriteResult(1, tailPath.Distinct().Count());