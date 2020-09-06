using System.Collections.Generic;

namespace AcyclicGraphPathFinder
{
    public class Node
    {
        public Node(int nodeKey)
        {
            Key = nodeKey;
            ConnectedNodes = new List<Node>();
        }

        public int Key { get; set; }
        public List<Node> ConnectedNodes { get; set; }
    }
}