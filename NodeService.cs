using System.Collections.Generic;
using System.Linq;

namespace AcyclicGraphPathFinder
{
    public class NodeService
    {
        public List<List<int>> FindNodePaths(List<Node> nodesList, int startNodeKey, int endNodeKey)
        {
            var startNode = nodesList.First(x => x.Key == startNodeKey);

            var result = GetNodePathRecursive(
                nodesList.Except(new List<Node> { startNode }).ToList(),
                startNode.Key,
                endNodeKey);

            return result;
        }

        private List<List<int>> GetNodePathRecursive(
            List<Node> nodesList,
            int startNodeKey,
            int nodeKey,
            List<int> currentList = null, List<List<int>> results = null)
        {
            results ??= new List<List<int>>();

            var node = nodesList.First(x => x.Key == nodeKey);

            var tempCurrentList = new List<int>();

            foreach (var connectedNode in node.ConnectedNodes)
            {
                tempCurrentList.Clear();

                if (currentList != null)
                    tempCurrentList.AddRange(currentList);

                if (!tempCurrentList.Contains(nodeKey))
                    tempCurrentList.Add(nodeKey);

                if (connectedNode.Key == startNodeKey)
                {
                    if (!tempCurrentList.Contains(connectedNode.Key))
                        tempCurrentList.Add(connectedNode.Key);

                    results.Add(tempCurrentList);

                    continue;
                }

                GetNodePathRecursive(nodesList, startNodeKey, connectedNode.Key, tempCurrentList, results);
            }

            return results;
        }
    }
}