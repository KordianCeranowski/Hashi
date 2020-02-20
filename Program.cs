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
                ((Node)item).CheckAvaliableConnections();
                ((Node)item).TwoConnectionsThreeValue();
            }

            //((Node)map[0, 0]).TwoConnectionsThreeValue();

            Console.WriteLine(map.ToString());

            Console.WriteLine();

        }
    }
}
