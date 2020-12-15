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
            
            int result2 = SolvePart2(directions);
            Console.WriteLine($"Part2 result = {result2}");
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

        static int SolvePart2(List<string> directions)
        {
            Ferry theFerry = new Ferry('E');
            theFerry.SetEWWaypoint('E',10);
            theFerry.SetNSWaypoint('N',1);

            foreach(string dir in directions)
            {
                theFerry.MoveWaypoint(dir);
                //Console.ReadKey();
            }

            return theFerry.GetManhattanDistance();
        }
    }
    class Ferry
    {
        private char _faceDirection;
        private Dictionary<char,int> _points = new Dictionary<char, int>();
        private Dictionary<char,int> _wayPoints = new Dictionary<char, int>();
        
        Tuple<char, int> _wpointEW ;
        Tuple<char, int> _wpointNS ;
        
        public Ferry(char direction)
        {
            _faceDirection = direction;
            
            _points.Clear();
            _points.Add('E',0);
            _points.Add('W',0);
            _points.Add('S',0);
            _points.Add('N',0);

            _wayPoints.Add('E',0);
            _wayPoints.Add('W',0);
            _wayPoints.Add('S',0);
            _wayPoints.Add('N',0);

        }
        public void SetEWWaypoint(char dir, int value)
        {
            _wpointEW = Tuple.Create(dir,value);
            //_points[dir] +=value;
            _wayPoints[dir] += value;
        }
        public void SetNSWaypoint(char dir, int value)
        {
            _wpointNS = Tuple.Create(dir,value);
            //_points[dir] +=value;
            _wayPoints[dir] += value;
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
                case 'S':
                case 'E':
                case 'W':
                    _points[whereDirection] += result;
                    break;
                case 'F':
                    _points[_faceDirection] += result;
                    break;
                case 'R':
                case 'L':
                    _faceDirection = Rotate(whereDirection, result);
                    break;  

            }
            
            //Console.WriteLine($"INS = {instruction}  -> E = {_east} W = {_west} N = {_north} S= {_south} FD = {_faceDirection} MD = {GetManhattanDistance()}");
            //Console.WriteLine("--");
        }

        public void MoveWaypoint(string instruction)
        {
            char whereDirection = instruction[0];
            int result = Int32.Parse(instruction.Substring(1));
            char tempDir ;
            int tempValue =0;
            // Console.WriteLine("--");
            // Console.WriteLine($"INS = {instruction}  -> EW = {_eastWestCount} NS = {_nortSouthCount} FD = {_faceDirection} LEW = {_lastEWDirection} LNS = {_lastNSDirection}  MD = {GetManhattanDistance()}");
            
            switch(whereDirection)
            {

                case 'N':
                case 'S':
                case 'E':
                case 'W':
                    _wayPoints[whereDirection] += result;

                    if(whereDirection =='N' || whereDirection=='S')
                    {
                        tempDir =_wpointNS.Item1;
                        if(tempDir == whereDirection) tempValue = _wpointNS.Item2 + result;
                        else tempValue = Math.Abs(_wpointNS.Item2 - result);
                        _wpointNS = Tuple.Create(tempDir,tempValue);
                    }
                    else
                    {
                        tempDir =_wpointEW.Item1;
                        if(tempDir == whereDirection) tempValue = _wpointEW.Item2 + result;
                        else tempValue = Math.Abs(_wpointEW.Item2 - result);
                        tempValue = _wpointEW.Item2 + result;
                        _wpointEW = Tuple.Create(tempDir,tempValue);
                    }

                    break;
                case 'F':
                    char tempDir1 = _wpointEW.Item1;
                    int tempValue1 = _wpointEW.Item2 * result;
                    //_wpointEW = Tuple.Create(tempDir, tempValue);
                    _points[tempDir1] += tempValue1;
                    char tempDir2 = _wpointNS.Item1;
                    int tempValue2 = _wpointNS.Item2 * result;
                    //_wpointNS = Tuple.Create(tempDir,tempValue);
                    _points[tempDir2] += tempValue2;
                    break;
                case 'R':
                case 'L':
                    char tempDir3 = _wpointEW.Item1;
                    int tempValue3 = _wpointEW.Item2 ;
                    char tempDirX = Rotate(whereDirection, result,tempDir3);
                    //_wpointEW = Tuple.Create(tempDir, tempValue);

                    char tempDir4 = _wpointNS.Item1;
                    int tempValue4 = _wpointNS.Item2;
                    char tempDirY = Rotate(whereDirection, result,tempDir4);
                    
                    if(tempDirY=='N' || tempDirY=='S')
                    {
                        _wpointNS = Tuple.Create(tempDirY, tempValue4);
                        _wpointEW = Tuple.Create(tempDirX, tempValue3);
                    }
                    else
                    {
                        _wpointNS = Tuple.Create(tempDirX, tempValue3);
                        _wpointEW = Tuple.Create(tempDirY, tempValue4);
                    }

                    //_wpointNS = Tuple.Create(tempDir, tempValue);
                    break;  

            }
            Console.WriteLine($"INS = {instruction}  -> E = {_points['E']} W = {_points['W']} N = {_points['N']} S= {_points['S']} W1={_wpointEW.ToString()} W2={_wpointNS.ToString()} MD = {GetManhattanDistance()}");
            //Console.WriteLine("--");
        }

        private Char Rotate(char where, int angle, char origDir = 'X')
        {
            List<char> right =new List<char>() {'N','E','S','W'};
            List<char> left = new List<char>(){'N','W','S','E'};
            
            char dir =_faceDirection;
            int factor = angle/90;
            int start = 0;

            char startDir;

            if(origDir == 'X') startDir = _faceDirection;
            else startDir = origDir;

            if (where == 'L') 
            {
                start = left.IndexOf(startDir);

                while(factor > 0)
                {
                    if(start + 1 < 4) start ++;
                    else start = 0;
                    
                    factor --;
                }

                dir = left[start];
            }
            else 
            {
                start= right.IndexOf(startDir);

               while(factor > 0)
                {
                    if(start+1 <4) start ++;
                    else start = 0;
                    
                    factor--;
                }


                dir = right[start];
            }

            return dir;
        }

        public int GetManhattanDistance()
        {
            return Math.Abs(_points['E'] - _points['W']) + Math.Abs(_points['N'] - _points['S']);
        }

    }
}
