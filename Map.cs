using System;
using System.Collections.Generic;

namespace Mosty
{
    class Map
    {
        readonly Dictionary<Tuple<int, int>, object> fields;
        readonly public int Rows;
        readonly public int Columns;

        public Map(int rows, int columns)
        {
            this.fields = new Dictionary<Tuple<int, int>, object>();
            Rows = rows;
            Columns = columns;
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

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (this[row, col] == null)
                    {
                        mapString += " ";
                    }
                    else
                    {
                        mapString += ((Node)this[row, col]).value.ToString();
                    }
                }
                mapString += "\n";
            }
            return mapString;
        }

        public bool IsNode(int row, int col)
        {
            if (this[row, col] == null)
                return false;
            return this[row, col].GetType() == typeof(Mosty.Node);
        }

        public bool IsBridge(int row, int col)
        {
            if (this[row, col] == null)
                return false;
            return this[row, col].GetType() == typeof(Mosty.Bridge);
        }

    }
}
