using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace day11
{
    class Program
    {
        const char EMPTY = 'L';
        const char OCCUPIED = '#';
        const char FLOOR = '.';
        static int numberOfCols = 10;
        static void Main(string[] args)
        {
            List<string> rowOfSeats = new List<string>();

            //get the numbers
            foreach(string rowSeat in File.ReadLines("input.txt"))
            {
                rowOfSeats.Add(rowSeat);
            }

            //sanity check
            //Console.WriteLine(rowOfSeats[rowOfSeats.Count-1]);

            //PrintList(rowOfSeats);
            numberOfCols = rowOfSeats[0].Length;
            // long result1 = SolvePart1(rowOfSeats);
            // Console.WriteLine($"Part1 result = {result1}");

            long result2 = SolvePart2(rowOfSeats);
            Console.WriteLine($"Part2 result = {result2}");
        }

        static int SolvePart1(List<string> rowOfSeats)
        {
            int noOfOccupied = 0;
            bool withMovements = true;
            //PrintList(rowOfSeats);
            List<string> origRowOfSeats = new List<string>();
            origRowOfSeats.AddRange(rowOfSeats);

            int currentRow = 0;
            while(withMovements)
            {
                currentRow = 0;
                int movements =0;
                foreach(string rowSeat in rowOfSeats)
                {
                    StringBuilder newRow = new StringBuilder();
                    char[] temp = rowSeat.ToArray();
                    for(int i=0; i<rowSeat.Length; i++)
                    {
                        
                        if(rowSeat[i] == EMPTY)
                        {
                            if(!HasAdjacent1(rowOfSeats,currentRow,i,true))
                            {
                                temp[i] = OCCUPIED;
                                origRowOfSeats[currentRow] = new string(temp);
                                movements++;

                            }
                            //PrintList(origRowOfSeats);
                            //Console.ReadLine();
                        }
                        else if(rowSeat[i] == OCCUPIED)
                        {
                            if(HasAdjacent1(rowOfSeats,currentRow,i,false))
                            {
                                temp[i] = EMPTY;
                                origRowOfSeats[currentRow] = new string(temp);
                                movements++;
                            }
                        }
                        else
                        {
                            temp[i] = rowSeat[i];
                            origRowOfSeats[currentRow] = new string(temp);
                        }
                    }
                    currentRow ++;
                }
                rowOfSeats.Clear();
                rowOfSeats.AddRange(origRowOfSeats);
                if (movements == 0) break;
            }
            
            foreach(string row in rowOfSeats)
            {
                noOfOccupied += row.Count(x => x == OCCUPIED);
            }

            //PrintList(newRowOfSeats);
            return noOfOccupied;
        }

        static int SolvePart2(List<string> rowOfSeats)
        {
            int noOfOccupied = 0;
            bool withMovements = true;
            List<string> origRowOfSeats = new List<string>();
            origRowOfSeats.AddRange(rowOfSeats);

            int currentRow = 0;
            while(withMovements)
            {
                currentRow = 0;
                int movements =0;
                foreach(string rowSeat in rowOfSeats)
                {
                    StringBuilder newRow = new StringBuilder();
                    char[] temp = rowSeat.ToArray();
                    for(int i=0; i<rowSeat.Length; i++)
                    {
                        
                        if(rowSeat[i] == EMPTY)
                        {
                            if(!IsOccupied(rowOfSeats,currentRow,i,true))
                            {
                                temp[i] = OCCUPIED;
                                origRowOfSeats[currentRow] = new string(temp);
                                movements++;

                            }
                            //PrintList(origRowOfSeats);
                            //Console.ReadLine();
                        }
                        else if(rowSeat[i] == OCCUPIED)
                        {
                            if(IsOccupied(rowOfSeats,currentRow,i,false))
                            {
                                temp[i] = EMPTY;
                                origRowOfSeats[currentRow] = new string(temp);
                                
                                movements++;
                            }
                        }
                        else
                        {
                            temp[i] = rowSeat[i];
                            origRowOfSeats[currentRow] = new string(temp);
                        }
                    }
                    //Console.WriteLine("3333  " + new string(temp) + "   3333");
                    currentRow ++;
                    //Console.ReadKey();
               
                }
                rowOfSeats.Clear();
                rowOfSeats.AddRange(origRowOfSeats);
                if (movements == 0) 
                {
                    break;
                }
                else
                {
                    Console.WriteLine(movements);
                }
                // PrintList(rowOfSeats);
                // Console.ReadKey();
            }
            
            foreach(string row in rowOfSeats)
            {
                noOfOccupied += row.Count(x => x == OCCUPIED);
            }

            //PrintList(newRowOfSeats);
            return noOfOccupied;
        }


        static bool HasAdjacent1(List<string> rowOfSeats, int currentRow, int currentCol, bool isEmpty)
        {
            bool result = false;
            int empty = 0;
            
            for(int row = currentRow-1; row<currentRow+2; row++)
            {
                for(int col = currentCol -1; col<currentCol+2; col++)
                {
                    if(row>=0 && row<rowOfSeats.Count)
                    {
                        if(col>=0 && col<numberOfCols)
                        {
                            if(row==currentRow && col==currentCol)
                            {
                                continue;
                            }
                            else
                            {
                                if(rowOfSeats[row][col]==EMPTY || rowOfSeats[row][col]==FLOOR)
                                {
                                    empty++;
                                }
                            }
                        } else empty++;
                    }
                    else empty++;
                }

            }

            if (isEmpty)
            {
                if (empty == 8) result = false;
                else result = true;
            }
            else
            {
                if(empty<=4) result = true;
                else result = false;
            }
            
          
            return result;
        }

        static bool IsOccupied(List<string> rowOfSeats, int currentRow, int currentCol, bool isEmpty)
        {
            bool result = false;
            int occupied = 0;

            int col=0;
            int row=0;

            //check horizontal back
            

            col = currentCol-1;
            row = currentRow;
            while(col>=0)
            {
                if(rowOfSeats[row][col]==OCCUPIED)
                {
                    occupied++;
                    break;
                } 
                else if(rowOfSeats[row][col]==EMPTY)
                {
                    break;
                }
                col--;
            }

            //check horizontal foraward
            col = currentCol+1;
            row = currentRow;
            while(col< numberOfCols)
            {
                if(rowOfSeats[row][col]==OCCUPIED)
                {
                    occupied++;
                    break;
                }
                 else if(rowOfSeats[row][col]==EMPTY)
                {
                    break;
                }
                col++;
            }

            //check upward
            col = currentCol;
            row = currentRow -1;
            while(row>=0)
            {
                if(rowOfSeats[row][col]==OCCUPIED)
                {
                    occupied++;
                    break;
                }
                 else if(rowOfSeats[row][col]==EMPTY)
                {
                    break;
                }
                row--;
            }

            //check downward
            col = currentCol;
            row = currentRow +1;
            while(row< rowOfSeats.Count)
            {
                if(rowOfSeats[row][col]==OCCUPIED)
                {
                    occupied++;
                    break;
                }
                 else if(rowOfSeats[row][col]==EMPTY)
                {
                    break;
                }
                row++;
            }

            //check nw
            col = currentCol -1;
            row = currentRow -1;
            while(col>=0 && row>=0)
            {
                if(rowOfSeats[row][col]==OCCUPIED)
                {
                    occupied++;
                    break;
                }
                 else if(rowOfSeats[row][col]==EMPTY)
                {
                    break;
                }
                row--;
                col--;
            }

            //check sw
            col = currentCol -1;
            row = currentRow +1;
            while(col>=0 && row<rowOfSeats.Count)
            {
                if(rowOfSeats[row][col]==OCCUPIED)
                {
                    occupied++;
                    break;
                }
                 else if(rowOfSeats[row][col]==EMPTY)
                {
                    break;
                }
                row++;
                col--;
            }

            //check ne
            col = currentCol +1;
            row = currentRow -1;
            while(col<numberOfCols && row>=0)
            {
                if(rowOfSeats[row][col]==OCCUPIED)
                {
                    occupied++;
                    break;
                }
                 else if(rowOfSeats[row][col]==EMPTY)
                {
                    break;
                }
                row--;
                col++;
            }

            //check se
            col = currentCol +1;
            row = currentRow +1;
            while(col<numberOfCols && row<rowOfSeats.Count)
            {
                if(rowOfSeats[row][col]==OCCUPIED)
                {
                    occupied++;
                    break;
                }
                 else if(rowOfSeats[row][col]==EMPTY)
                {
                    break;
                }
                row++;
                col++;
            }
            //Console.WriteLine($"occs = {occupied}");

            if (isEmpty)
            {
                if (occupied ==0) result = false;
                else result = true;
            }
            else
            {
                if(occupied>=5) result = true;
                else result = false;
            }
            
          
            return result;
        }
         
        static void PrintList(List<string> seats)
        {
            Console.WriteLine("*********************");
            foreach(string seat in seats)
            {
                Console.WriteLine(seat);
            }
        }
    }
}
