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
        static int ROW_COLS = 10;
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
            ROW_COLS = rowOfSeats[0].Length;
            long result1 = SolvePart1(rowOfSeats);
            Console.WriteLine($"Part1 result = {result1}");

            // long result2 = SolvePart2(adapters);
            // Console.WriteLine($"Part2 result = {result2}");
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
                    //Console.WriteLine(rowSeat);
                    StringBuilder newRow = new StringBuilder();
                    char[] temp = rowSeat.ToArray();
                    for(int i=0; i<rowSeat.Length; i++)
                    {
                        
                        if(rowSeat[i] == EMPTY)
                        {
                            if(!HasAdjacent(rowOfSeats,currentRow,i,true))
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
                            if(HasAdjacent(rowOfSeats,currentRow,i,false))
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
                        //Console.ReadLine();
                    }
                    //Console.WriteLine("777" + newRow.ToString());
                    //origRowOfSeats[currentRow]=newRow.ToString();
                    
                    currentRow ++;
                }
                PrintList(origRowOfSeats);
                rowOfSeats.Clear();
                rowOfSeats.AddRange(origRowOfSeats);
                if (movements == 0)
                {
                    break;
                }
            }
            
            foreach(string row in rowOfSeats)
            {
                noOfOccupied += row.Count(x => x == OCCUPIED);
            }

            //PrintList(newRowOfSeats);
            return noOfOccupied;
        }

        static bool HasAdjacent(List<string> rowOfSeats, int currentRow, int currentCol, bool isEmpty)
        {
            bool result = false;
            int empty = 0;
            
            for(int row = currentRow-1; row<currentRow+2; row++)
            {
                for(int col = currentCol -1; col<currentCol+2; col++)
                {
                    if(row>=0 && row<rowOfSeats.Count)
                    {
                        if(col>=0 && col<ROW_COLS)
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
        //static 
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
