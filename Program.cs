using System;

namespace Hashi
{
    class Program
    {
        static void Main(string[] args)
        {
            MapReader mapReader = new MapReader();
            Map map = mapReader.Read();
            Console.WriteLine(map.ToString());

            foreach (var item in map.nodes)
            {
                item.AllConnectionsOccupied(2);
            }

            Console.WriteLine(map.ToString());

            map.BuildBridge(((Node)map[0, 0]), ((Node)map[0, 2]));
            Console.WriteLine(map.ToString());

            Console.WriteLine();

        }
    }
}
