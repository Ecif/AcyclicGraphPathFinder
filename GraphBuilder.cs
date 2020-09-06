using System.Collections.Generic;
using System.Linq;

namespace AcyclicGraphPathFinder
{
    public class GraphBuilder
    {
        public List<Node> BuildNodesStructure(List<(int, int ConnectionEnd)> graph, int node1, int node2)
        {
            var nodesList = new List<Node>
            {
                new Node(node2), new Node(node1)
            };

            foreach (var (_, endNode) in graph)
            {
                var mainNode = nodesList.FirstOrDefault(x => x.Key == endNode);

                if (mainNode == null)
                {
                    mainNode = new Node(endNode);

                    nodesList.Add(mainNode);
                }


                foreach (var (connectionStart, _) in graph.Where(x => x.ConnectionEnd == mainNode.Key))
                {
                    var connectionNode = nodesList.FirstOrDefault(x => x.Key == connectionStart);

                    if (connectionNode == null)
                    {
                        connectionNode = new Node(connectionStart);
                        nodesList.Add(connectionNode);
                    }

                    mainNode.ConnectedNodes ??= new List<Node>();

                    if (mainNode.ConnectedNodes.All(x => x.Key != connectionNode.Key))
                        mainNode.ConnectedNodes.Add(connectionNode);
                }
            }

            return nodesList;
        }

    }
}