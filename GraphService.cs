using System.Collections.Generic;

namespace AcyclicGraphPathFinder
{
    public class GraphService
    {
        private readonly GraphBuilder _graphBuilder;
        private readonly NodeService _nodeService;

        public GraphService()
        {
            _graphBuilder = new GraphBuilder();
            _nodeService = new NodeService();
        }

        public List<List<int>> FindAllPaths(List<(int, int)> graph, int startNodeKey, int endNodeKey)
        {
            var structuredNodes = _graphBuilder.BuildNodesStructure(graph, startNodeKey, endNodeKey);

            var result = _nodeService.FindNodePaths(structuredNodes, startNodeKey, endNodeKey);

            return result;
        }
    }
}