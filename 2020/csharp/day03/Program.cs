using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace day03
{
    class Program
    {
        const char TREE='#';
        const char OPEN = '.';
        static void Main(string[] args)
        {
            List<string> map = new List<string>();
            int mapSegmentWidth = 0;
            int mapSegmentHeight = 0;
            string slopePart1 = "31"; // [xy]
            // populate the map
            foreach(string mapLine in File.ReadLines("input.txt"))
            {
                map.Add(mapLine);
            }

            mapSegmentWidth = map[0].Length - 1;
            mapSegmentHeight = map.Count - 1;

            // let check
            Console.WriteLine($"Slope = [{slopePart1[0]},{slopePart1[1]}]");
            Console.WriteLine($"Map = [{mapSegmentWidth},{mapSegmentHeight}]");

            int treeCountPart1 = TraverseMap(map,mapSegmentWidth, mapSegmentHeight, slopePart1);

            Console.WriteLine($"Part1 Result = {treeCountPart1}");

            List<String> slopes = new List<string>()
            {
                "11","31","51","71","12"
            };

            long part2Result = 1;
            foreach(string slope in slopes)
            {
                int count = TraverseMap(map,mapSegmentWidth, mapSegmentHeight, slope);
                part2Result = part2Result * count;
            }

            Console.WriteLine($"Part2 Result = {part2Result}");

        }

        static int TraverseMap(
            List<string> map, 
            int mapX,
            int mapY,
            string slope
        )
        {
            int treeCount = 0;

            int x = 0;
            int y = 0;
            while(y < mapY)
            {
                x = x + Int32.Parse(slope[0].ToString());

                // return back to 0
                if (x > mapX)
                {
                    x = x - mapX - 1;
                }    

                y = y + Int32.Parse(slope[1].ToString());

                if (map[y][x] == TREE) 
                {
                    treeCount++;
                }
            }

            return treeCount;
        }
    }
}
