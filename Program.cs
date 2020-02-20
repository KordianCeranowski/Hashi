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
            //Node test = (Node)map[0, 0];
            //test.CheckAvaliableConnections();


            Console.WriteLine();

        }
    }
}
