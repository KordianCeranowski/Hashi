using System;

namespace Mosty
{
    class Program
    {
        static void Main(string[] args)
        {
            MapReader mapReader = new MapReader();
            Map map = mapReader.Read();
            Console.WriteLine(map.ToString());
            Node test = (Node)map[3, 4];
            Node test2 = (Node)map[6, 4];
            var test3 = (Node)map[0, 2];

            map.BuildBridge(test2, test);

            test3.CheckAvaliableConnections();

            //test.CheckAvaliableConnections();
            Console.WriteLine(map.ToString());

            test = (Node)map[2, 0];
            test2 = (Node)map[2, 3];
            map.BuildBridge(test2, test);

            test3.CheckAvaliableConnections();

            Console.WriteLine(map.ToString());

            Console.WriteLine();

        }
    }
}
