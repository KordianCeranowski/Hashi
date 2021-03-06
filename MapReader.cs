﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hashi
{
    class MapReader
    {
        string path = @"..\..\..\maps\map.txt";
        Map map;

        public Map Read()
        {
            var sizes = GetMapSize();
            map = new Map(sizes.Item1, sizes.Item2);
            Node.map = map;
            FillMapMatrix();

            return map;
        }

        private void FillMapMatrix()
        {
            using var reader = new StreamReader(path);
            int currRow = -1;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                line = line.Replace(' ', '0');
                currRow++;
                for (int currCol = 0; currCol < line.Length; currCol++)
                {
                    int value = int.Parse(line[currCol].ToString());
                    if(value > 0)
                    {
                        Node temp = new Node(value, currRow, currCol);
                        map[currRow, currCol] = temp;
                        map.nodes.Add(temp);
                    }
                }
            }
        }

        Tuple<int, int> GetMapSize()
        {
            using var reader = new StreamReader(path);
            int lineCount = 0;
            int lineLength = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                lineCount++;
                lineLength = line.Length;
            }
            return Tuple.Create(lineCount, lineLength);

        }
    }
}
