using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace day12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> directions = new List<string>();

            foreach(string dir in File.ReadLines("input.txt"))
            {
                directions.Add(dir);
            }

            int result1 = SolvePart1(directions);
            Console.WriteLine($"Part1 result = {result1}");
        }

        static int SolvePart1(List<string> directions)
        {
            Ferry theFerry = new Ferry('E');

            foreach(string dir in directions)
            {
                theFerry.Move(dir);
                //Console.ReadKey();
            }

            return theFerry.GetManhattanDistance();
        }
    }
    class Ferry
    {
        private char _faceDirection;
        // private int _eastWestCount;
        // private int _nortSouthCount;
        // private char _lastNSDirection;
        // private char _lastEWDirection;

        private int _north =0;
        private int _south=0;
        private int _west =0;
        private int _east=0;


        public Ferry(char direction)
        {
            _faceDirection = direction;
            // _eastWestCount = 0;
            // _nortSouthCount = 0;
            // _lastNSDirection = 'X';
            // _lastEWDirection = 'X';
        }

        public void Move(string instruction)
        {
            char whereDirection = instruction[0];
            int result = Int32.Parse(instruction.Substring(1));

            // Console.WriteLine("--");
            // Console.WriteLine($"INS = {instruction}  -> EW = {_eastWestCount} NS = {_nortSouthCount} FD = {_faceDirection} LEW = {_lastEWDirection} LNS = {_lastNSDirection}  MD = {GetManhattanDistance()}");
            
            switch(whereDirection)
            {

                case 'N':
                    _north +=result;
                    break;
                case 'S':
                    _south +=result;
                    break;
                case 'E':
                    _east += result;
                    break;
                case 'W':
                    _west += result;
                    break;
                case 'F':
                    switch(_faceDirection)
                    {
                        case 'N':
                            _north +=result;
                            break;
                        case 'S':
                            _south +=result;
                            break;
                        case 'E':
                            _east += result;
                            break;
                        case 'W':
                            _west += result;
                            break;
                    }
                    break;
                case 'R':
                case 'L':
                    _faceDirection = Rotate(whereDirection, result);
                    break;  


                // case 'N':
                //     if (_lastNSDirection == 'S') _nortSouthCount = Math.Abs(_nortSouthCount - result);
                //     else if (_lastNSDirection == 'N') _nortSouthCount += result;
                //     else _nortSouthCount = result;

                //     _lastNSDirection =whereDirection;
                //     break;
                // case 'S':
                //     if (_lastNSDirection == 'N') _nortSouthCount = Math.Abs(_nortSouthCount - result);
                //     else if (_lastNSDirection == 'S') _nortSouthCount += result;
                //     else _nortSouthCount = result;

                //     _lastNSDirection =whereDirection;
                //     break;
                // case 'E':
                //     if (_lastEWDirection == 'W') _eastWestCount =Math.Abs(_eastWestCount - result);
                //     else if (_lastEWDirection == 'E') _eastWestCount += result;
                //     else _eastWestCount = result;

                //     _lastEWDirection =whereDirection;
                //     break;
                // case 'W':
                //     if (_lastEWDirection == 'E') _eastWestCount =Math.Abs(_eastWestCount - result);
                //     else if (_lastEWDirection == 'W') _eastWestCount += result;
                //     else _eastWestCount = result;

                //     _lastEWDirection =whereDirection;
                //     break;
                // case 'F':
                
                //     if (_faceDirection == 'S' && _lastNSDirection == 'S') _nortSouthCount += result;
                //     else if(_faceDirection == 'S' && _lastNSDirection == 'N') _nortSouthCount = Math.Abs(_nortSouthCount - result);
                //     else if(_faceDirection == 'N' && _lastNSDirection == 'N') _nortSouthCount += result;
                //     else if(_faceDirection == 'N' && _lastNSDirection == 'S') _nortSouthCount = Math.Abs(_nortSouthCount - result);
                //     else if(_faceDirection == 'E' && _lastEWDirection == 'W') _eastWestCount =Math.Abs(_eastWestCount - result);
                //     else if(_faceDirection == 'E' && _lastEWDirection == 'E') _eastWestCount += result;
                //     else if(_faceDirection == 'W' && _lastEWDirection == 'W') _eastWestCount += result;
                //     else if(_faceDirection == 'W' && _lastEWDirection == 'E') _eastWestCount =Math.Abs(_eastWestCount - result);
                //     else if((_faceDirection == 'E' || _faceDirection=='W') && _lastEWDirection == 'X') 
                //     {
                //         _eastWestCount += result;
                //         _lastEWDirection = _faceDirection;
                //     }
                //     else if((_faceDirection == 'N' || _faceDirection=='S') && _lastEWDirection == 'X') 
                //     {
                //         _nortSouthCount += result;
                //         _lastNSDirection = _faceDirection;
                //     }
                //     else
                //     {
                //         if(_faceDirection == 'N' || _faceDirection == 'S') _nortSouthCount += result;
                //         else _eastWestCount += result;
                //     }
                //     break;
                // case 'R':
                // case 'L':
                //     _faceDirection = Rotate(whereDirection, result);
                //     break;            

            }
            Console.WriteLine($"INS = {instruction}  -> E = {_east} W = {_west} N = {_north} S= {_south} FD = {_faceDirection} MD = {GetManhattanDistance()}");
            //Console.WriteLine("--");
        }

        private Char Rotate(char where, int angle)
        {
            List<char> right =new List<char>() {'N','E','S','W'};
            List<char> left = new List<char>(){'N','W','S','E'};
            char dir =_faceDirection;
            int factor = angle/90;
            int start = 0;

            if (where == 'L') 
            {
                start = left.IndexOf(_faceDirection);

                while(factor > 0)
                {
                    if(start+1<4)
                    {
                        start ++;
                    }
                    else
                    {
                        start = 0;
                    }
                    factor --;
                }

                dir = left[start];
            }
            else 
            {
                start= right.IndexOf(_faceDirection);

               while(factor > 0)
                {
                    if(start+1<4)
                    {
                        start ++;
                    }
                    else
                    {
                        start = 0;
                    }
                    factor--;
                }


                dir = right[start];
            }

            return dir;
            
        }

        public int GetManhattanDistance()
        {
            return Math.Abs(_east - _west) + Math.Abs(_north - _south);
        }

    }
}
