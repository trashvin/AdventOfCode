using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace day05
{
    class Program
    {
        static int lastRow = 127;
        static int lastColumn = 8; //start at 1

        static void Main(string[] args)
        {
            List<string> boardingTickets = new List<string>();
            // read all data
            foreach(string ticket in File.ReadLines("input.txt"))
            {
                boardingTickets.Add(ticket);
            }
            // health check
            // foreach(string ticket in boardingTickets)
            // {
            //     Console.WriteLine(ticket);
            // }

            // do part1 and part2
            Tuple<int, int> result1 = GetSeatInformation(boardingTickets);
            
            Console.WriteLine($"Part1 MaxSeatID = {result1.Item1}");
            Console.WriteLine($"Part2 MySeat = {result1.Item2}");

        }

        static Tuple<int,int> GetSeatInformation(List<string> boardingTickets)
        {
            List<int> seatList = new List<int>();
            int maxSeatID = 0;
            int lastRowValue = lastRow;
            int lastColValue = lastColumn;
            int startRowValue = 1;
            int startColValue = 1;
            foreach(string ticket in boardingTickets)
            {
                startColValue = 0;
                startRowValue = 0;
                lastColValue =  lastColumn;
                lastRowValue = lastRow;
                for(int row =0; row<10; row++)
                {
                    // get direction
                    char direction = ticket[row];
                    if(row<7)
                    {
                        if (direction == 'F')
                        {
                            lastRowValue = ((lastRowValue-startRowValue)  / 2) + startRowValue;
                        }
                        else
                        {
                            startRowValue = ((lastRowValue-startRowValue)  / 2)+startRowValue;
                        }
                    }
                    else
                    {
                        if (direction == 'L')
                        {
                            lastColValue = ((lastColValue-startColValue)  / 2) + startColValue;
                        }
                        else
                        {
                            startColValue = ((lastColValue-startColValue)  / 2)+startColValue;
                        }
                    }
                }
                // Console.WriteLine($"{startRowValue} : {startColValue}");
                // add 1 because our counting started at 0
                int seatID = (startRowValue +1)*8 + startColValue;
                //Console.WriteLine($"SeatID = {ticket} : {seatID}");

                if(startRowValue>0 && startRowValue <127)
                {
                    seatList.Add(seatID);
                }

                if (seatID > maxSeatID) maxSeatID = seatID;
            }

            // get your seat

            seatList.Sort();
            int mySeatID = 0;
            for(int i=0; i<seatList.Count;i++)
            {
                if((i+1) < seatList.Count+1)
                {
                    int diff = Math.Abs(seatList[i]-seatList[i+1]);
                    if(diff == 2)
                    {
                        // Console.WriteLine($"{seatList[i]} , {seatList[i+1]}");
                        mySeatID = seatList[i] + 1;
                        break;
                    }
                }
                //Console.Write(i.ToString() + " -- ");
            }
            //Console.WriteLine("");
            return Tuple.Create<int,int>(maxSeatID, mySeatID);
        }
    }
}
