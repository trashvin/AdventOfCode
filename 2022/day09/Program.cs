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


// Part 2

List<int> xHeads = new List<int>()
{
    1,1,1,1,1,1,1,1,1,1
};
List<int> yHeads = new List<int>()
{
    1,1,1,1,1,1,1,1,1,1
};
//List<int> xTails = new List<int>()
//{
//    1,1,1,1,1,1,1,1,1,1
//};
//List<int> yTails = new List<int>()
//{
//    1,1,1,1,1,1,1,1,1,1
//};

headPath.Clear();
tailPath.Clear();

headPath = xHeads
    .Select(loc => "1:1").ToList();

foreach (var movement in movements)
{
    var dir = movement.Item1;
    var steps = movement.Item2;

    for (int step = 0; step < steps; step++)
    {
        if (dir == "R") xHeads[0] += 1;
        else if (dir == "L") xHeads[0] -= 1;
        else if (dir == "U") yHeads[0] += 1;
        else yHeads[0] -= 1;

        headPath.Add(xHeads[0] + ":" + yHeads[0]);
        for (int rope = 1; rope< 10; rope++)
        {
            //int xhDisplacement = xHeads[rope-1]- xHeads[rope];
            //int yhDisplacement = yHeads[rope-1]- yHeads[rope];

            //if (xhDisplacement > 1) xHeads[rope] += 1;
            //else if (xhDisplacement < -1) xHeads[rope] -= 1;

            //if (yhDisplacement > 1) yHeads[rope] += 1;
            //else if(yhDisplacement < -1) yHeads[rope] -= 1;

            int xDisplacement = xHeads[rope - 1] - xHeads[rope];
            int yDisplacement = yHeads[rope- 1] - yHeads[rope];

            if (xDisplacement > 1)
            {
                xHeads[rope] += 1;
                if (yDisplacement > 0) yHeads[rope] += 1;
                else if (yDisplacement < 0) yHeads[rope] -= 1;
            }
            else if (xDisplacement < -1)
            {
                xHeads[rope] -= 1;

                if (yDisplacement > 0) yHeads[rope] += 1;
                else if (yDisplacement < 0) yHeads[rope] -= 1;
                
            }
            else if (yDisplacement > 1)
            {
                yHeads[rope] += 1;
                if (xDisplacement > 0) xHeads[rope] += 1;
                else if (xDisplacement < 0) xHeads[rope] -= 1;
            }
            else if (yDisplacement < -1)
            {
                yHeads[rope]-= 1;
                if (xDisplacement > 0) xHeads[rope] += 1;
                else if (xDisplacement < 0) xHeads[rope] -= 1;
            }


            headPath.Add(xHeads[rope] + ":" + yHeads[rope]);
            tailPath.Add(xHeads[9] + ":" + yHeads[9]);
        }

        
    }


}

Helper.WriteResult(2, tailPath.Distinct().Count().ToString());  










