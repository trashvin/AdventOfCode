// See https://aka.ms/new-console-template for more information
using helper;

List<string> input = Helper.ReadList<string>("data.txt");
// rock, paper , scissaor
string[] opponentMoves = { "A", "B", "C" };
string[] yourMoves = { "X", "Y", "Z" };

int score = 0;

foreach(var round in input)
{
    string[] moves = round.Split(' ');
    int pos1 = Array.FindIndex(opponentMoves, item => item == moves[0]);
    int pos2 = Array.FindIndex(yourMoves, item => item == moves[1]);
    int result =  pos1 - pos2;
    
   switch(result)
    {
        case 0: // draw
            score += 3 + (pos2 + 1);
            break;
        case -1: // win
            score += 6 + (pos2 + 1);
            break;
        case 1: //
            score += 0 + (pos2 + 1);
            break;
        case -2: // loss
            score += 0 + (pos2 + 1);
            break;
        case 2:
            score += 6 + (pos2 + 1);
            break;
    }

}

Helper.WriteResult(1, score);

// part 2
score = 0;
foreach (var round in input)
{
    string[] moves = round.Split(' ');
    
    int pos1 = Array.FindIndex(opponentMoves, item => item == moves[0]);
    int pos2 = 0;
    switch (moves[1])
    {
        case "X":
            if (pos1 >0) pos2 = pos1 - 1;
            else pos2 = 2;
            break;
        case "Y":
            pos2 = pos1;
            break;
        case "Z":
            if (pos1 <2) pos2 = pos1 + 1;
            else pos2 = 0;
            break;
    }
    int result = pos1 - pos2;

    switch (result)
    {
        case 0: // draw
            score += 3 + (pos2 + 1);
            break;
        case -1: // win
            score += 6 + (pos2 + 1);
            break;
        case 1: //
            score += 0 + (pos2 + 1);
            break;
        case -2: // loss
            score += 0 + (pos2 + 1);
            break;
        case 2:
            score += 6 + (pos2 + 1);
            break;
    }
}
Helper.WriteResult(2, score);
