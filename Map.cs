using System;
using System.Collections.Generic;

namespace Hashi
{
    class Map
    {
        readonly public Dictionary<Tuple<int, int>, object> fields;
        readonly public int Rows;
        readonly public int Columns;
        readonly List<Bridge> bridges;
        readonly public List<Node> nodes;

        public Map(int rows, int columns)
        {
            this.fields = new Dictionary<Tuple<int, int>, object>();
            Rows = rows;
            Columns = columns;
            bridges = new List<Bridge>();
            nodes = new List<Node>();
        }

        public void BuildBridge(Node nodeOne, Node nodeTwo)
        {
            int rowDiff = 0;
            int colDiff = 0;
            int multiplyier;
            if (nodeOne.Row == nodeTwo.Row)
            {
                colDiff = 1;
                if (nodeOne.Col < nodeTwo.Col)
                    multiplyier = 1;
                else
                    multiplyier = -1;
            }
            else
            {
                rowDiff = 1;
                if (nodeOne.Row < nodeTwo.Row)
                    multiplyier = 1;
                else
                    multiplyier = -1;
            }

            int rowOne = nodeOne.Row; 
            int colOne = nodeOne.Col;
            int rowTwo = nodeTwo.Row;
            int colTwo = nodeTwo.Col;

            Bridge bridge = new Bridge(nodeOne, nodeTwo);
            bridges.Add(bridge);

            rowOne += rowDiff * multiplyier;
            colOne += colDiff * multiplyier;

            while (!(rowOne == rowTwo && colOne == colTwo))
            {
                this[rowOne, colOne] = bridge;
                rowOne += rowDiff * multiplyier;
                colOne += colDiff * multiplyier;
            }
        }

        public object this[int row, int col]
        {
            get => GetObject(row, col);
            set => SetObject(row, col, value);
        }

        private object GetObject(int row, int col)
        {
            CheckRange(row, col);
            var coordinates = Tuple.Create(row, col);
            if (fields.ContainsKey(coordinates))
                return fields[coordinates];
            else
                return null; 
        } 

        private void SetObject(int row, int col, object value)
        {
            CheckRange(row, col);
            fields[Tuple.Create(row, col)] = value;
        }

        public bool IsInRange(int row, int col)
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Columns)
                return true;
            else
                return false;
        }

        private void CheckRange(int row, int col)
        {
            if (!IsInRange(row, col))
                throw new Exception("Point out of range");
        }

        public override string ToString()
        {
            string mapString = "";
            string separator = "  ";

            mapString += separator + " ";
            for (int i = 0; i < Columns; i++)
            {
                mapString += i + separator;
            }
            mapString += "\n";


            for (int row = 0; row < Rows; row++)
            {
                mapString += row + separator;

                for (int col = 0; col < Columns; col++)
                {
                    if (this[row, col] == null)
                    {
                        mapString += " ";
                    }
                    else if (IsNode(row, col))
                    {
                        mapString += ((Node)this[row, col]).value.ToString();
                    }
                    else
                    {
                        mapString += ((Bridge)this[row, col]).ToString();
                    }

                    mapString += separator;
                    
                }
                mapString += "\n";
            }
            return mapString;
        }

        public bool IsNode(int row, int col)
        {
            if (this[row, col] == null)
                return false;
            return this[row, col].GetType() == typeof(Hashi.Node);
        }

        public bool IsBridge(int row, int col)
        {
            if (this[row, col] == null)
                return false;
            return this[row, col].GetType() == typeof(Hashi.Bridge);
        }

    }
}
