using System;
using System.Collections.Generic;

namespace Hashi
{
    class Node
    {

        public static Map map;
        public int value;
        public int Row, Col;
        public List<Node> AvaliableNodes;


        public void TwoConnectionsThreeValue()
        {
            if (value == 3 && AvaliableNodes.Count == 2)
            {
                map.BuildBridge(this, AvaliableNodes[0]);
                map.BuildBridge(this, AvaliableNodes[1]);
            } 
        }


        public void CheckAvaliableConnections()
        {
            AvaliableNodes.Clear();
            //   U|
            // L--*--R
            //   D|

            //Left
            CheckNegativePartOfX();
            //Right
            CheckPositivePartOfX();
            //Down
            CheckNegativePartOfY();
            //Up
            CheckPositivePartOfY();
        }

        private void CheckNegativePartOfX()
        {
            for (int currCol = Col - 1; currCol >= 0; currCol--)
            {
                if (FoundObstacle(Row, currCol))
                    break;

                if (map.IsNode(Row, currCol))
                {
                    AvaliableNodes.Add((Node)map[Row, currCol]);
                    break;
                }
            }
        }
        private void CheckPositivePartOfX()
        {
            for (int currCol = Col + 1; currCol < map.Columns; currCol++)
            {
                if (FoundObstacle(Row, currCol))
                    break;

                if (map.IsNode(Row, currCol))
                {
                    AvaliableNodes.Add((Node)map[Row, currCol]);
                    break;
                }
            }
        }
        private void CheckNegativePartOfY()
        {
            for (int currRow = Row + 1; currRow < map.Rows; currRow++)
            {
                if (FoundObstacle(currRow, Col))
                    break;

                if (map.IsNode(currRow, Col))
                {
                    AvaliableNodes.Add((Node)map[currRow, Col]);
                    break;
                }
            }
        }
        private void CheckPositivePartOfY()
        {
            for (int currRow = Row - 1; currRow >= 0; currRow--)
            {
                if (FoundObstacle(currRow, Col))
                    break;

                if (map.IsNode(currRow, Col))
                {
                    AvaliableNodes.Add((Node)map[currRow, Col]);
                    break;
                }
            }
        }


        private bool FoundObstacle(int row, int col)
        {
            if ((!map.IsInRange(row, col) || FieldHasUnusableBridge(row, col)))
                return true;
            else
                return false;
        }

        private bool FieldHasUnusableBridge(int row, int col)
        {
            if (map.IsBridge(row, col))
            {
                Bridge bridge = (Bridge)map[row, col];
                if (!bridge.IsUsableFor(this))
                {
                    return true;
                }
            }
            return false;
        }


        public Node(int value, int row, int col)
        {
            this.value = value;
            this.Row = row;
            this.Col = col;
            this.AvaliableNodes = new List<Node>();
        }

        public override string ToString()
        {
            return "(" + Row.ToString() + ", " + Col.ToString() + "): " + value.ToString();
        }
    }
}
