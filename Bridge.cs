namespace Hashi
{
    class Bridge
    {
        public Node nodeOne;
        public Node nodeTwo;
        public int usedConnections;

        public Bridge(Node nodeOne, Node nodeTwo)
        {
            this.nodeOne = nodeOne;
            this.nodeTwo = nodeTwo;
            this.usedConnections = 1;
        }

        public override string ToString()
        {
            if (usedConnections == 1)
                return "-";
            else
                return "=";
        }

        public bool IsUsableFor(Node node)
        {
            return Contains(node) && HasConnectionsAvaliable();
        }

        public bool Contains(Node node)
        {
            return nodeOne == node || nodeTwo == node;
        }

        public bool HasConnectionsAvaliable()
        {
            return usedConnections < 2;
        }

        public override bool Equals(object obj)
        {
            return this.nodeOne == ((Bridge)obj).nodeOne && this.nodeTwo == ((Bridge)obj).nodeTwo;
        }
    }
}
//test
